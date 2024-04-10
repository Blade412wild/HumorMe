using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class StatManager : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float maxHealthBar;

    private float currentHumor;

    // Start is called before the first frame update
    void Start()
    {
        currentHumor = maxHealthBar;
        healthBar.SetMaxValue(maxHealthBar);
    }
    public void DecreaseHumor(float value)
    {
        currentHumor -= value;
        UpdateUI();
    }

    public void UpdateUI()
    {
        healthBar.SetValue(currentHumor);
    }

    public void TestEvent()
    {
        EventManagerEnum.Instance.TriggerEvent(EventManagerEnum.EventType.OnTransition);
        Debug.Log("ivoked Event");
    }
}
