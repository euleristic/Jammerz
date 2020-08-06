using System;
using UnityEngine;

public interface IShip
{
    void Shoot();
    void Damage(int incomingDamage);
    Action<bool> ShootEvent { get; set; }
}
