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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            DecreaseHumor(10);
        }
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
}
