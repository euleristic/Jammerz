using System;
using UnityEngine;
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Rigidbody2D))]
public class TestEnemy : MonoBehaviour, IShip
{
    public Action<bool> ShootEvent { get; set; }
    private Health _health;
    protected IMovementType _movement;
    protected Weapon _weapon;
    [SerializeField] private SoundEffect _deathSound;
    protected void Start()
    {
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
    }
    public void Shoot()
    {
        if(ShootEvent != null)
        {
            ShootEvent.Invoke(false);
        }
    }
    private void Die()
    {
        if (_deathSound != null) SoundEffects.PlaySoundEffect(_deathSound);
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
