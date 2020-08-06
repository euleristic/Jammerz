using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float _shootSpeed, _spread;
    private float _lastShot = -1000f;

    [SerializeField] private SoundEffect _shootSound;


    protected virtual void Shoot(bool enemy)
    {
        if (!CanShoot()) return;
        if(_projectile == null)
        {
            Debug.LogError("There's no projectile to shoot you knob");
            return;
        }

        SoundEffects.PlaySoundEffect(_shootSound);

        var p = Instantiate(_projectile, transform.position, transform.rotation);

        p.GetComponent<DamageOnContact>().SetEnemy(enemy);

        /*Delete pls*/
        p.transform.rotation = p.transform.rotation.AddRotation(Random.Range(-_spread, _spread));
        if(TimeManager.Debugging) p.GetComponent<SpriteRenderer>().color = enemy ? Color.red : Color.green;
        _lastShot = TimeManager.GetRelativeTime();
    }

    public bool CanShoot()
    {
        //print (TimeManager.GetRelativeTime() > _lastShot + _shootSpeed || TimeManager.GetRelativeTime() < _lastShot);
        return TimeManager.GetRelativeTime() > _lastShot + _shootSpeed || TimeManager.GetRelativeTime() < _lastShot;
    }

    private void OnEnable()
    {
        var ship = GetComponentInParent<IShip>();
        if (ship != null) ship.ShootEvent += Shoot;
    }

    private void OnDisable()
    {
        var ship = GetComponentInParent<IShip>();
        if (ship != null) ship.ShootEvent -= Shoot;
    }
}
