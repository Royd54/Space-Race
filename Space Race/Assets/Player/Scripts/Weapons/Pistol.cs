using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Pistol : Weapon
{
    [SerializeField] private Projectile _bulletPrefab;
    [SerializeField] private AudioClip _shootFX;

    protected override void StartShooting(XRBaseInteractor interactor)
    {
        base.StartShooting(interactor);
        Shoot();
    }

    protected override void Shoot()
    {
        base.Shoot();
        Projectile projectileInstance = Instantiate(_bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        AudioManager.Instance.PlaySFX(_shootFX);
        projectileInstance.Init(this);
        projectileInstance.Launch();
    }

    public void ShootForAI(Vector3 player)
    {
        bulletSpawn.transform.LookAt(player);
        Projectile projectileInstance = Instantiate(_bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        AudioManager.Instance.PlaySFX(_shootFX);
        projectileInstance.Init(this);
        projectileInstance.Launch();
    }

    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor);
    }
}
