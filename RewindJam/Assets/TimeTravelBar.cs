using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTravelBar : MonoBehaviour
{
    private TimeTraveller _tt;
    private Image _img;
    void Start()
    {
        _tt = FindObjectOfType<TimeTraveller>();
        _img = GetComponent<Image>();
    }

    private void FixedUpdate()
    {

        _img.fillAmount = _tt.GetSlowDownMeterPercent();
    }

}
