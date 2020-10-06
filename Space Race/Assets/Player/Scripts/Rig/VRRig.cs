using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap
{
    [SerializeField] private Transform _vrTarget;
    [SerializeField] private Transform _rigTarget;
    [SerializeField] private Vector3 _trackingPositionOffset;
    [SerializeField] private Vector3 _trackingRotationOffset;

    public void Map()
    {
        _rigTarget.position = _vrTarget.TransformPoint(_trackingPositionOffset);
        _rigTarget.rotation = _vrTarget.rotation * Quaternion.Euler(_trackingRotationOffset);
    }
}

public class VRRig : MonoBehaviour
{
    [SerializeField] private VRMap _head;
    [SerializeField] private VRMap _leftHand;
    [SerializeField] private VRMap _rightHand;

    [SerializeField] private Transform _headConstraint;
    [SerializeField] private Vector3 _headBodyOffset;

    [SerializeField] private float _turnSmoothing;

    // Start is called before the first frame update
    void Start()
    {
        _headBodyOffset = transform.position - _headConstraint.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = _headConstraint.position + _headBodyOffset;
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(_headConstraint.up, Vector3.up).normalized, Time.deltaTime * _turnSmoothing);

        _head.Map();
        _leftHand.Map();
        _rightHand.Map();
    }
}
