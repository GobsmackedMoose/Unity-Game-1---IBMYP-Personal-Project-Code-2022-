using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class healthbar : MonoBehaviour
{
    public Slider sl;


    public void MaxHealthSetter(int maxHealth)
    {
        sl.maxValue = maxHealth;

    }

    public void HealthSetter(int health)
    {
        sl.value = health;
    }
}
