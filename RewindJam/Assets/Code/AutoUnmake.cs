using UnityEngine;

public class AutoUnmake : MonoBehaviour
{
    private float _startTime;
    private void Start()
    {
        _startTime = TimeManager.GetRelativeTime();
    }
    private void FixedUpdate()
    {
        if(TimeManager.GetRelativeTime() < _startTime)
        {
            Destroy(gameObject);
        }
    }
}
