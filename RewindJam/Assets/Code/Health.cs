using Boo.Lang;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _health;
    [SerializeField] private int _maxHealth;
    private List<HealthChangeInstance> _healthChangeInstances = new List<HealthChangeInstance>();

    private void Start()
    {
        _health = _maxHealth;
    }

    public void Heal(int health)
    {
        _health += health;
        _health = Mathf.Min(_health, _maxHealth);
        _healthChangeInstances.Add(new HealthChangeInstance(health));
    }
    public void Damage(int incomingDamage)
    {
        _health -= incomingDamage;
        _healthChangeInstances.Add(new HealthChangeInstance(-incomingDamage));
    }

    public bool Dead()
    {
        return _health < 0;
    }
    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.O))
        {
            Damage(3);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Heal(2);
        }

        if(TimeManager.GetTimeFactor() < 0f)
        {
            for (int i = 0; i < _healthChangeInstances.Count; i++)
            {
                int index = _healthChangeInstances.Count - i - 1;
                if (TimeManager.GetRelativeTime() < _healthChangeInstances[i].relativeTime)
                {
                    _health -= _healthChangeInstances[i].delta;
                    _healthChangeInstances.RemoveAt(i);
                }
                else break;
            }
        }
    }
}

public class HealthChangeInstance
{
    public HealthChangeInstance(int change)
    {
        delta = change;
        relativeTime = TimeManager.GetRelativeTime();
    }
    public int delta;
    public float relativeTime;
}

