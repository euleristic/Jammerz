using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{
    private Health _playerHealth;
    private List<Image> _playerHealthBits = new List<Image>();
    private float _healthOffset;
    [SerializeField] private Sprite[] _firstHealthSprites, _otherHealthSprites;

    private void Start()
    {
        _playerHealth = FindObjectOfType<Player>().GetComponent<Health>();


        for (int i = 0; i < transform.childCount; i++)
        {
           if(transform.GetChild(i).GetComponent<Image>() != null)
           {
               _playerHealthBits.Add(transform.GetChild(i).GetComponent<Image>());
           }
        }
        foreach (var img in _playerHealthBits)
        {
            img.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        for(int i = 0; i < _playerHealth.GetMaxHealth(); i++)
        {
            _playerHealthBits[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < _playerHealth.GetMaxHealth(); i++)
        {
            int index = i > _playerHealth.GetCurrentHealth() -1 ? 0 : 1;

            if (i == 0) _playerHealthBits[0].sprite = _firstHealthSprites[index];
            else _playerHealthBits[i].sprite = _otherHealthSprites[index];
        }
    }
}
