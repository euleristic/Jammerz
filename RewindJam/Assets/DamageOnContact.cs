using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private bool _destroyOnImpact = true;
    private bool _enemy;
    [SerializeField] private SoundEffect _onHitSoundEffect;


    public void SetEnemy(bool enemy)
    {
        _enemy = enemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IShip hit = collision.transform.GetComponent<IShip>();
        if(!_enemy && hit is EnemyBase && TimeManager.GetTimeFactor() > 0 || _enemy && hit is Player)
        {
            hit.Damage(_damage);
            if (_onHitSoundEffect != null) SoundEffects.PlaySoundEffect(_onHitSoundEffect);
            Explosions.SpawnExplosion(transform.position);
            if (_destroyOnImpact) 
                DeletedObjectHandler.DestroyObject(gameObject);
        }
    }
}
