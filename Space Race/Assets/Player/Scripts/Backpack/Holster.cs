using System;
using UnityEngine;

public class Holster : MonoBehaviour
{
    [SerializeField] private GameObject _headAnchor;
    [SerializeField] private float _rotationspeed = 50f;
    [SerializeField] private float _turnSmoothing;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_headAnchor.transform.position.x, _headAnchor.transform.position.y / 2, _headAnchor.transform.position.z);

        var rotationDifference = Math.Abs(_headAnchor.transform.eulerAngles.y - transform.eulerAngles.y);
        var finalRotationSpeed = _rotationspeed;

        if (rotationDifference > 60)
            finalRotationSpeed = _rotationspeed * 2;
        else if (rotationDifference > 40 && rotationDifference < 60)
            finalRotationSpeed = _rotationspeed;
        else if (rotationDifference < 40 && rotationDifference > 20)
            finalRotationSpeed = _rotationspeed / 2;
        else if (rotationDifference < 20 && rotationDifference > 0)
            finalRotationSpeed = _rotationspeed / 4;

        var step = finalRotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, _headAnchor.transform.eulerAngles.y, 0), step);
        //Quaternion.Lerp(transform.rotation, Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, _headAnchor.transform.eulerAngles.y, 0), step), Time.deltaTime * _turnSmoothing);
    }
}
