using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public static Action<float> SetMaxValue;

    public static Action<float> ChangeValue;

    private void Start()
    {
        SetMaxValue += (x) => { _slider.maxValue = x; };
        ChangeValue += (x) => { _slider.value = x; };
    }





}
