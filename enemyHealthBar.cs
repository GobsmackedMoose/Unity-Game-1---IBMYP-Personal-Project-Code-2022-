using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealthBar : MonoBehaviour
{
    public Slider sli;
    // Start is called before the first frame update
    void MaxHealthSetter(int maxHealth)
    {
        sli.maxValue = maxHealth;
    }

    // Update is called once per frame
    void currentHealthSetter(int health)
    {
        sli.value = health;
    }
}
