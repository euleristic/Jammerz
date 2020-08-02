using UnityEngine;
public interface IPlayerInput
{
    Vector2 MovementVector();
    bool Shooting();
    bool Reversing();
}
