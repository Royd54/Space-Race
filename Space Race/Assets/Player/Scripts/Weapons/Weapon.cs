using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(XRGrabInteractable))]
public class Weapon : MonoBehaviour
{
    [SerializeField] protected float shootingForce;
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] private float _recoilForce;
    [SerializeField] private float _damage;

    private Rigidbody _rigidBody;
    private XRGrabInteractable _interactableWeapon;

    protected virtual void Awake()
    {
        if(gameObject.layer != 13) { _interactableWeapon = GetComponent<XRGrabInteractable>(); }
        
        _rigidBody = GetComponent<Rigidbody>();
        SetupInteractableWeaponEvents();
    }

    private void SetupInteractableWeaponEvents()
    {
        if (gameObject.layer != 13)
        {
            //interactableWeapon.onSelectEnter.AddListener(PickUpWeapon);
            //interactableWeapon.onSelectExit.AddListener(DropWeapon);
            _interactableWeapon.onActivate.AddListener(StartShooting);
            _interactableWeapon.onDeactivate.AddListener(StopShooting);
        }
    }

   /* private void PickUpWeapon(XRBaseInteractor interactor)
    {
        interactor.GetComponentInChildren<MeshHidder>().Hide();
    }
 
    private void DropWeapon(XRBaseInteractor interactor)
    {
        interactor.GetComponentInChildren<MeshHidder>().Show();

    }
    */

    protected virtual void StartShooting(XRBaseInteractor interactor)
    {

    }

    protected virtual void StopShooting(XRBaseInteractor interactor)
    {

    }

    protected virtual void Shoot()
    {
        ApplyRecoil();
    }

    private void ApplyRecoil()
    {
        _rigidBody.AddRelativeForce(Vector3.back * _recoilForce, ForceMode.Impulse);
    }

    public float GetShootingForce()
    {
        return shootingForce;
    }

    public float GetDamage()
    {
        return _damage;
    }
}
