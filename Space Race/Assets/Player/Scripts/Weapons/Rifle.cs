using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Rifle : Weapon
{
    [SerializeField] private float _fireRate;
    private Projectile _projectile;

    private WaitForSeconds _wait;

    protected override void Awake()
    {
        base.Awake();
        _projectile = GetComponentInChildren<Projectile>();
    }

    private void Start()
    {
        _wait = new WaitForSeconds(1 / _fireRate);
        _projectile.Init(this);
    }

    protected override void StartShooting(XRBaseInteractor interactor)
    {
        base.StartShooting(interactor);
        StartCoroutine(ShootingCO());
    }

    private IEnumerator ShootingCO()
    {
        while (true)
        {
            Shoot();
            yield return _wait;
        }
    }

    protected override void Shoot()
    {

        base.Shoot();
        _projectile.Launch();
    }

    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor);
        StopAllCoroutines();
    }
}
