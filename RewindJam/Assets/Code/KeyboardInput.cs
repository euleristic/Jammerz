using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour, IPlayerInput
{
    [SerializeField] private KeyCode _shoot = KeyCode.Z, _reverse = KeyCode.X;

    public Vector2 MovementVector()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public bool Reversing()
    {
        return Input.GetKey(_reverse);
    }

    public bool Shooting()
    {
        return Input.GetKey(_shoot);
    }
}
