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
        _spawnTime = TimeManager.GetRelativeTime();
        startPos = transform.position;
    }
    private void Update()
    {
        transform.position = transform.position.With(x: startPos.x + Mathf.Sin((TimeManager.GetRelativeTime() - _spawnTime) * speed), y:startPos.y + (TimeManager.GetRelativeTime() - _spawnTime) * speed);

        transform.rotation = transform.rotation.Set2DRotation(Mathf.Cos(TimeManager.GetRelativeTime() * speed) * 15f);
        //transform.rotation = transform.rotation.AddRotation(TimeManager.GetTimeFactor() * Time.deltaTime * 100f);
        if (TimeManager.GetRelativeTime() < _spawnTime) Destroy(gameObject);
    }
}
