using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_Shooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float range = 10.0f;
    
        public GameObject healthBar;
        public int maxHealth = 3;
    
     private int health;


    private float timer;
    private GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
          player = GameObject.FindGameObjectWithTag("Player");
                 healthBar.SendMessage("MaxHealthSetter", maxHealth);


    }

    // Update is called once per frame
    void Update()
    {
       healthBar.SendMessage("currentHealthSetter", health);

        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < range)
        {
            timer += Time.deltaTime;

            if (timer > 3.2)
            {
                timer= 0;
                shoot();
            }
        }


         if (health < 1)
        {
            Destroy(gameObject);
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    void ChangeHealth(int amountChanged)
    {
        health = health + amountChanged;
    }
   
}
