using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineEnemy : EnemyBase
{
    [SerializeField] private float _leftSpeed, _sineHeight, _sineSpeed;
    private bool _down;
    private void FixedUpdate()
    {
        _movement.Move(new Vector2(-_leftSpeed, (Mathf.Cos(TimeManager.GetRelativeTime() * _sineSpeed) * _sineHeight * _sineSpeed)));
        //GetComponent<IMovementType>().SetSpeedMultiplier(15);
        if (_down && !(Mathf.Cos(TimeManager.GetRelativeTime() * _sineSpeed) * _sineHeight * _sineSpeed < 0) || !_down && (Mathf.Cos(TimeManager.GetRelativeTime() * _sineSpeed) * _sineHeight * _sineSpeed < 0)) Shoot();
        _down = Mathf.Cos(TimeManager.GetRelativeTime() * _sineSpeed) * _sineHeight * _sineSpeed < 0;
    }
}
