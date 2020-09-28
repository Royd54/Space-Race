using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandPhysics : MonoBehaviour
{
    [SerializeField] private float _smoothingAmount = 15f;
    [SerializeField] private Transform _target = null;

    private Rigidbody _rigidBody = null;
    private Vector3 _targetPosition = Vector3.zero;
    private Quaternion _targetRotation = Quaternion.identity;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        TeleportToTarget();
    }

    private void Update()
    {
        SetTargetPosition();
        SetTargetRotation();
    }

    private void SetTargetPosition()
    {
        float time = _smoothingAmount * Time.unscaledDeltaTime;
        _targetPosition = Vector3.Lerp(_targetPosition, _target.position, time);
    }

    private void SetTargetRotation()
    {
        float time = _smoothingAmount * Time.unscaledDeltaTime;
        _targetRotation = Quaternion.Slerp(_targetRotation, _target.rotation, time);
    }

    private void FixedUpdate()
    {
        MoveToController();
        RotateToController();
    }

    private void MoveToController()
    {
        Vector3 positionDelta = _targetPosition - transform.position;

        _rigidBody.velocity = Vector3.zero;
        _rigidBody.MovePosition(transform.position + positionDelta);
    }

    private void RotateToController()
    {
        _rigidBody.angularVelocity = Vector3.zero;
        _rigidBody.MoveRotation(_targetRotation);
    }

    public void TeleportToTarget()
    {
        _targetPosition = _target.position;
        _targetRotation = _target.rotation;

        transform.position = _targetPosition;
        transform.rotation = _targetRotation;
    }
}
