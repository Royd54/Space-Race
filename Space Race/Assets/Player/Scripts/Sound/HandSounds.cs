using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class HandSounds : XRDirectInteractor
{
    [SerializeField] private AudioClip _pickupSoundFX;
    [SerializeField] private AudioClip _bagGrabFX;
    [SerializeField] private AudioClip _bagSlotFX;

    private GameObject _inSocket = null;

    protected override void OnSelectEnter(XRBaseInteractable interactable)
    {
        base.OnSelectEnter(interactable);
            AudioManager.Instance.PlaySFX(_pickupSoundFX);
    }

    public void PlayBagGrabFX()
    {
        AudioManager.Instance.PlaySFX(_bagGrabFX);
    }

    public void PlayBagSlotFX()
    {
        AudioManager.Instance.PlaySFX(_bagSlotFX);
    }

    private void OnTriggerStay(Collider other)
    {
            _inSocket = other.gameObject;
    }
}
