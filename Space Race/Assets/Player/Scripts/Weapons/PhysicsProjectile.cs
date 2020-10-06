using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsProjectile : Projectile
{
    [SerializeField] private float _lifeTime;
    private Rigidbody rigidBody;

    [SerializeField] private GameObject _explosionFX;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public override void Init(Weapon weapon)
    {
        base.Init(weapon);
        Destroy(gameObject, _lifeTime);
    }

    public override void Launch()
    {
        base.Launch();
        rigidBody.AddRelativeForce(Vector3.forward * weapon.GetShootingForce(), ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(_explosionFX, transform.position, other.gameObject.transform.rotation);
        Destroy(gameObject);
        ITakeDamage[] damageTakers = other.GetComponentsInParent<ITakeDamage>();

        foreach (var taker in damageTakers)
        {
            taker.TakeDamage(weapon, this, transform.position);
        }
    }
}
