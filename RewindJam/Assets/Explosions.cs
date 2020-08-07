using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    [SerializeField] private static float _waitTime = 0.1f;
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
    public static void SpawnExplosions(Vector2 pos, Vector2 half, int amount)
    {
        _instance.StartCoroutine(_instance.ExplosionSpread(pos, half, amount));
    }
    public static void SpawnExplosions(Vector2 pos, SpriteRenderer sr, int amount)
    {
        SpawnExplosions(pos, sr.bounds.extents, amount);
    }

    private IEnumerator ExplosionSpread(Vector2 pos, Vector2 half, int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            SpawnExplosion(pos + new Vector2(Random.Range(-half.x, half.x), Random.Range(-half.y, half.y)));
            yield return new WaitForSeconds(_waitTime);
        }
        yield return null;
    }

    public void Update()
    {
        //fuckin backwards shit
    }

}
