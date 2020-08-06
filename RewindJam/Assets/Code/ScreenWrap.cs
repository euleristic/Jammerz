using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera _cam;
    private Vector2 _positionLastFrame = new Vector2(69,69);
    [SerializeField] private bool _horizontal = false, _vertical = true;
    private SpriteRenderer _sr;
    [SerializeField] private Mode _wrapMode;
    private enum Change
    {
        Positive,
        Negative,
        Nothing
    }
    private enum Mode
    {
        Wrap,
        Destroy,
        Constrain
    }
    private void Start()
    {
        _cam = FindObjectOfType<Camera>();
        _sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Vector2 c = (Vector2)transform.position - _positionLastFrame;
        float offsetmultiplier;
        switch(_wrapMode) //who fucking cares
        {
            case Mode.Constrain:
                offsetmultiplier = -1;
                break;
            default:
                offsetmultiplier = 1;
                break;
        }
        if(_horizontal)
        {
            Change hor;
            if (c.x > 0f) hor = Change.Positive;
            else if (c.x < 0f) hor = Change.Negative;
            else hor = Change.Nothing;
            if (_cam.WorldToScreenPoint((Vector2)transform.position + ((_sr.size * offsetmultiplier) / 2)).x < 0f && hor == Change.Negative)
            {
                switch(_wrapMode)
                {
                    case Mode.Wrap:
                        transform.position = transform.position.With(x: _cam.ScreenToWorldPoint(new Vector3((float)Screen.width, 0f, 0f)).x);
                        transform.position += Vector3.right * (_sr.size.x / 2);
                        break;
                    case Mode.Destroy:
                        DeletedObjectHandler.DestroyObject(gameObject);
                        break;
                    case Mode.Constrain:
                        transform.position = transform.position.With(x: _cam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - ((_sr.size * offsetmultiplier) / 2).x);
                        break;
                }

            }
            else if (_cam.WorldToScreenPoint((Vector2)transform.position - (_sr.size * offsetmultiplier ) / 2).x > Screen.width && hor == Change.Positive)
            {
                switch (_wrapMode)
                {
                    case Mode.Wrap:
                        transform.position = transform.position.With(x: _cam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x);
                        transform.position -= Vector3.right * (_sr.size.x / 2);
                        break;
                    case Mode.Destroy:
                        DeletedObjectHandler.DestroyObject(gameObject);
                        break;
                    case Mode.Constrain:
                        transform.position = transform.position.With(x: _cam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + ((_sr.size * offsetmultiplier) / 2).x);
                        break;
                }
            }
        }
        if(_vertical)
        {
            Change ver;
            if (c.y > 0f) ver = Change.Positive;
            else if (c.y < 0f) ver = Change.Negative;
            else ver = Change.Nothing;

            if(_cam.WorldToScreenPoint((Vector2)transform.position + ((_sr.size * offsetmultiplier) / 2)).y < 0f && ver == Change.Negative)
            {

                switch (_wrapMode)
                {
                    case Mode.Wrap:
                        transform.position = transform.position.With(y: _cam.ScreenToWorldPoint(new Vector3(0f, (float)Screen.height, 0f)).y);
                        transform.position += Vector3.up * (_sr.size.y / 2);
                        break;
                    case Mode.Destroy:
                        DeletedObjectHandler.DestroyObject(gameObject);
                        break;
                    case Mode.Constrain:
                        transform.position = transform.position.With(y: _cam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - ((_sr.size * offsetmultiplier) / 2).y);
                        break;
                }


            }
            else if(_cam.WorldToScreenPoint((Vector2)transform.position - ((_sr.size * offsetmultiplier)/2)).y > Screen.height && ver == Change.Positive)
            {
                switch (_wrapMode)
                {
                    case Mode.Wrap:

                        transform.position = transform.position.With(y: _cam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y);
                        transform.position -= Vector3.up * (_sr.size.y / 2);
                        break;
                    case Mode.Destroy:
                        DeletedObjectHandler.DestroyObject(gameObject);
                        break;
                    case Mode.Constrain:
                        transform.position = transform.position.With(y: _cam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + ((_sr.size * offsetmultiplier) / 2).y);
                        break;
                }
            }
        }
        _positionLastFrame = transform.position;
    }
}
