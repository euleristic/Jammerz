using UnityEngine;

public class NormalMovement : MonoBehaviour,IMovementType
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _timeTravelling = true;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        float timeFactor = _timeTravelling ? TimeManager.GetTimeFactor() : Mathf.Abs(TimeManager.GetTimeFactor());
        if(_rb != null) _rb.velocity = direction * _speed * timeFactor;
        else
        {
            transform.position += (Vector3)direction * _speed * timeFactor * Time.fixedDeltaTime;
        }
    }
    public void MoveRelative(Vector2 direction)
    {
        Vector2 relativeMovement = transform.up * direction.y + transform.right * direction.x;
        float timeFactor = _timeTravelling ? TimeManager.GetTimeFactor() : Mathf.Abs(TimeManager.GetTimeFactor());
        if (_rb != null) _rb.velocity = relativeMovement * _speed * timeFactor;
        else
        {
            transform.position += (Vector3)relativeMovement * _speed * timeFactor * Time.fixedDeltaTime;
        }
    }
}
