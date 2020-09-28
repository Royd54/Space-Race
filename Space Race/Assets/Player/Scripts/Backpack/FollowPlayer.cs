using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    public int characterSlots = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (characterSlots == 1)
        {
            transform.position = _target.position + Vector3.up * _offset.y
             + Vector3.ProjectOnPlane(_target.right, Vector3.up).normalized * _offset.x
             + Vector3.ProjectOnPlane(_target.forward, Vector3.up).normalized * _offset.z;

            transform.eulerAngles = new Vector3(0, _target.eulerAngles.y, 0);
        }else
        {
            transform.position = _target.transform.position + _offset;
        }
    }
}
