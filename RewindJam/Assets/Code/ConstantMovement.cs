using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : NormalMovement
{
    public Vector2 _direction;
    [SerializeField] private bool _relativeToRotation;
    public void FixedUpdate()
    {
        if (!_relativeToRotation) Move(_direction);
        else
        {
            MoveRelative(_direction);
        }
    }
}
