using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour, ITakeDamage
{
    const string RUN_TRIGGER = "Run";
    const string CROUCH_TRIGGER = "Crouch";
    const string SHOOT_TRIGGER = "Shoot";

    [SerializeField] private float _startingHealth;
    [SerializeField] private float _minTimeUnderCover;
    [SerializeField] private float _maxTimeUnderCover;
    [SerializeField] private int _minShotsToTake;
    [SerializeField] private int _maxShotsToTake;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _damage;
    [Range(0, 100)]
    [SerializeField] private float _shootingAccuracy;

    [SerializeField] private Transform _shootingPosition;
    [SerializeField] private ParticleSystem _bloodSplatterFX;

    private bool _isShooting;
    private int _currentShotsTaken;
    private int _currentMaxShotsToTake;
    private NavMeshAgent _agent;
    private Player _player;
    private Transform _occupiedCoverSpot;
    private Animator _animator;

    private float _health;
    public float health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = Mathf.Clamp(value, 0, _startingHealth);
        }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _animator.SetTrigger(RUN_TRIGGER);
        _health = _startingHealth;
    }

    public void Init(Player player, Transform coverSpot)
    {
        _occupiedCoverSpot = coverSpot;
        this._player = player;
        GetToCover();
    }

    private void GetToCover()
    {
        _agent.isStopped = false;
        _agent.SetDestination(_occupiedCoverSpot.position);
    }

    private void Update()
    {
        if(_agent.isStopped == false && (transform.position - _occupiedCoverSpot.position).sqrMagnitude <= 0.1f)
        {
            _agent.isStopped = true;
            StartCoroutine(InitializeShootingCO());
        }
        if (_isShooting)
        {
            RotateTowardsPlayer();
        }
    }
    private IEnumerator InitializeShootingCO()
    {
        HideBehindCover();
        yield return new WaitForSeconds(UnityEngine.Random.Range(_minTimeUnderCover, _maxTimeUnderCover));
        StartShooting();
    }


    private void HideBehindCover()
    {
        _animator.SetTrigger(CROUCH_TRIGGER);
    }
    private void StartShooting()
    {
        _isShooting = true;
        _currentMaxShotsToTake = UnityEngine.Random.Range(_minShotsToTake, _maxShotsToTake);
        _currentShotsTaken = 0;
        _animator.SetTrigger(SHOOT_TRIGGER);
    }

    public void Shoot()
    {
        bool hitPlayer = UnityEngine.Random.Range(0, 100) < _shootingAccuracy;

        if (hitPlayer)
        {
            RaycastHit hit;
            Vector3 direction = _player.GetHeadPosition() - _shootingPosition.position;
            if(Physics.Raycast(_shootingPosition.position, direction, out hit))
            {
                Player player = hit.collider.GetComponentInParent<Player>();
                if (player)
                {
                    player.TakeDamage(_damage);
                }
            }
        }
        _currentShotsTaken++;
        if(_currentShotsTaken >= _currentMaxShotsToTake)
        {
            StartCoroutine(InitializeShootingCO());
        }
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = _player.GetHeadPosition() - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        transform.rotation = rotation;
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
