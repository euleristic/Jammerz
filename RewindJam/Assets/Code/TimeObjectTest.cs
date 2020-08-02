using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObjectTest : MonoBehaviour
{
    private float _spawnTime;
    private Vector2 startPos;
    [SerializeField] private float speed = 3;

    private void Start()
    {
        _spawnTime = Time.time;
        startPos = transform.position;
    }
    private void Update()
    {
        transform.position = transform.position.With(x: startPos.x + Mathf.Sin(TimeManager.GetRelativeTime() * speed), y:startPos.y - TimeManager.GetRelativeTime() * speed);
        if (TimeManager.GetRelativeTime() < _spawnTime) Destroy(gameObject);
    }
}
