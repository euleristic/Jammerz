using System;
using UnityEngine;
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBase : MonoBehaviour, IShip
{
    private float _startTime;
    public Action<bool> ShootEvent { get; set; }
    private Health _health;
    protected IMovementType _movement;
    protected Weapon _weapon;
    [SerializeField] private SoundEffect _deathSound;
    private SpriteRenderer _sr;
    protected void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _startTime = TimeManager.GetRelativeTime();
        _movement = GetComponent<IMovementType>();
        _health = GetComponent<Health>();
    }
    public void Damage(int incomingDamage)
    {
        _health.Damage(incomingDamage);
        if(_health.Dead())
        {
            Die();
        }
        _sr.color = Color.red;
        LeanTween.color(gameObject, Color.white, 0.25f);
    }
    public void Shoot()
    {
        if(ShootEvent != null)
        {
            ShootEvent.Invoke(true);
        }
    }
    private void Die()
    {
        if (_deathSound != null) SoundEffects.PlaySoundEffect(_deathSound);
        Explosions.SpawnExplosions(transform.position, _sr, 5);
        DeletedObjectHandler.DestroyObject(gameObject);        
    }

    private void OnEnable()
    {
        if(TimeManager.GetTimeFactor() < 0)
        {
            if (_deathSound != null) SoundEffects.PlaySoundEffect(_deathSound);
        }
    }
}
