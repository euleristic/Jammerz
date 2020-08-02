using System;
using UnityEngine;

public interface IShip
{
    void Shoot();
    Action<bool> ShootEvent { get; set; }
}
