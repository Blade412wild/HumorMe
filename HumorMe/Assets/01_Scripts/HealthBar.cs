using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;


    public void SetValue(float value)
    {
        Debug.Log(value);
        slider.value = value;
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }

    public void SetMaxValue(float value)
    {
        slider.maxValue = value;
        slider.value = value;
        fill.color = gradient.Evaluate(1f);

    }
}
