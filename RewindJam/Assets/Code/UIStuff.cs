using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStuff : MonoBehaviour
{
    private Vector3 _scale;
    [SerializeField] private float _tweenTime = 0.3f;
    private void OnEnable()
    {
        _scale = transform.localScale;
        transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, _scale, _tweenTime);
    }
}
