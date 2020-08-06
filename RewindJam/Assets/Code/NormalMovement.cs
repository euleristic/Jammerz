using UnityEngine;

public class NormalMovement : MonoBehaviour, IMovementType
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _timeTravelling = true;
    private float _speedMultiplier = 1f;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        float timeFactor = _timeTravelling ? TimeManager.GetTimeFactor() : Mathf.Abs(TimeManager.GetTimeFactor());
        if(_rb != null) _rb.velocity = direction  * _speed  * _speedMultiplier *  timeFactor;
        else
        {
            transform.position += (Vector3)direction  * _speed  * _speedMultiplier *  timeFactor * Time.fixedDeltaTime;
        }
    }
    public void MoveRelative(Vector2 direction)
    {
        Vector2 relativeMovement = transform.up * direction.y + transform.right * direction.x;
        float timeFactor = _timeTravelling ? TimeManager.GetTimeFactor() : Mathf.Abs(TimeManager.GetTimeFactor());
        if (_rb != null) _rb.velocity = relativeMovement  * _speed  * _speedMultiplier *  timeFactor;
        else
        {
            transform.position += (Vector3)relativeMovement  * _speed  * _speedMultiplier *  timeFactor * Time.fixedDeltaTime;
        }
    }

    public void SetSpeedMultiplier(float newSpeed)
    {
        _speedMultiplier = newSpeed;
    }
}
