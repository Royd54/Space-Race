using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage
{
    [SerializeField] float health;
    [SerializeField] Transform head;
    public static Player player;

    public Vector3 playerPos;
    [SerializeField] private ParticleSystem _bloodSplatterFX;

    private void FixedUpdate()
    {
        playerPos = transform.position;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.LogError(string.Format("Player health: {0}",health));
    }

    public Vector3 GetHeadPosition()
    {
        return head.position;
    }

    public Vector3 GetPlayerPos()
    {
        return playerPos;
    }

    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
    {
        health -= weapon.GetDamage();
        if (health <= 0)
            Destroy(gameObject);
        ParticleSystem effect = Instantiate(_bloodSplatterFX, contactPoint, Quaternion.LookRotation(weapon.transform.position - contactPoint));
        effect.Stop();
        effect.Play();
    }
}
