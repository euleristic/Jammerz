using System;
using UnityEngine;
public class Player : MonoBehaviour, IShip
{
    [SerializeField] float speed = 20f;

    private IPlayerInput _input;
    private IMovementType _movement;

    public Action<bool> ShootEvent { get; set; }

    private void Start()
    {
        _input    = GetComponent<IPlayerInput>();
        _movement = GetComponent<IMovementType>();
    }

    private void Update()
    {
        Movement();

        if (_input.Shooting()) ShootEvent.Invoke(false);
    }

    private void Movement()
    {
        _movement.Move(_input.MovementVector());
    }

    public void Shoot()
    {
        throw new NotImplementedException();
    }
}
