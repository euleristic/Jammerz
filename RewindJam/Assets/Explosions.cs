using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    [SerializeField] private float _maxRandomOffset;
    [SerializeField] private Transform _explosion;
    private static Explosions _instance;

    private Animator _animator;

    private void Start()
    {
        _instance = this;
        
    }
    public static void SpawnExplosion(Vector2 pos)
    {
        Instantiate(_instance._explosion, (Vector3)pos, Quaternion.identity.AddRotation(Random.Range(-180, 180)));
    }

    public void Update()
    {
        //fuckin backwards shit
    }

}
