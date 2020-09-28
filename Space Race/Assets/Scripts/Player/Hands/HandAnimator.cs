using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAnimator : MonoBehaviour
{
    [SerializeField] private XRController _controller = null;

    private float _speed = 5.0f;
    private Animator _animator = null;

    private readonly List<Finger> _gripFingers = new List<Finger>()
    {
        new Finger(FingerType.Middle),
        new Finger(FingerType.Ring),
        new Finger(FingerType.Pinky)
    };

    private readonly List<Finger> _pointFingers = new List<Finger>()
    {
        new Finger(FingerType.Index),
        new Finger(FingerType.Thumb)
    };

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckGrip();
        CheckPointer();

        SmoothFinger(_pointFingers);
        SmoothFinger(_gripFingers);

        AnimateFinger(_pointFingers);
        AnimateFinger(_gripFingers);
    }

    private void CheckGrip()
    {
        if (_controller.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            SetFingerTargets(_gripFingers, gripValue);
    }

    private void CheckPointer()
    {
        if (_controller.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float pointerValue))
            SetFingerTargets(_pointFingers, pointerValue);
    }

    private void SetFingerTargets(List<Finger> fingers, float value)
    {
        foreach (Finger finger in fingers)
            finger.target = value;
    }

    private void SmoothFinger(List<Finger> fingers)
    {
        foreach(Finger finger in fingers)
        {
            float time = _speed * Time.unscaledDeltaTime;
            finger.current = Mathf.MoveTowards(finger.current, finger.target, time);
        }
    }

    private void AnimateFinger(List<Finger> fingers)
    {
        foreach (Finger finger in fingers)
            AnimateFinger(finger.type.ToString(), finger.current);
    }

    private void AnimateFinger(string finger, float blend)
    {
        _animator.SetFloat(finger, blend);
    }
}