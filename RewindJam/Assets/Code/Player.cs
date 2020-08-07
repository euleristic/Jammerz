using System;
using UnityEngine;
public class Player : MonoBehaviour, IShip
{
    [SerializeField] private int _maxHealth = 3;
    private Health _health;
    private IPlayerInput _input;
    private IMovementType _movement;
    private TimeTraveller _timeTraveller;

    public Action<bool> ShootEvent { get; set; }

    private void Start()
    {
        _timeTraveller = GetComponent<TimeTraveller>();
        _health = GetComponent<Health>();
        _input    = GetComponent<IPlayerInput>();
        _movement = GetComponent<IMovementType>();
    }

    private void Update()
    {
        Movement();

        if (_input.Shooting()) Shoot();
        if(_input.Reversing() && _timeTraveller.CanReverseTime())
        {
            _timeTraveller.ReverseTime();
        }
        else
        {
            _timeTraveller.ResumeTime();
        }
    }

    private void Movement()
    {
        _movement.Move(_input.MovementVector());
    }

    public void Shoot()
    {
        ShootEvent.Invoke(false);
        _timeTraveller.ResetChargeTime();
    }

    public void Damage(int incomingDamage)
    {
        _health.Damage(incomingDamage);
    }
}
