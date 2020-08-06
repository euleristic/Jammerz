using UnityEngine;

public interface IMovementType
{
    void Move(Vector2 direction);
    void SetSpeedMultiplier(float newSpeed);
}
