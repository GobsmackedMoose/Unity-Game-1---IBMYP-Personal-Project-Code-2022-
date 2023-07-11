using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move2D : MonoBehaviour
{
    Rigidbody2D rigidBody2d;

    public int maxHealth = 10; 
    public int health { get { return currentHealth; }}
    public int currentHealth;
        public GameObject healthBar;

    public int proj = 1; 

    public float spd = 3.0f;
    
    
    float hRotation;



    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    public GameObject projectilePrefab;

    public float launchSpeed = 300.0f;





    Vector2 lookDirection = new Vector2(1,0);
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        currentHealth = maxHealth;
        rigidBody2d = GetComponent<Rigidbody2D>(); 

        //healthBar.MaxHealthSetter(maxHealth);
        healthBar.GetComponent<Slider>();
                        healthBar.SendMessage("MaxHealthSetter", maxHealth);


     

        
    }


    public void ChangeHealth(int amount)
    {
         if (amount < 0)
        {
            if (isInvincible)
                return;
            
                isInvincible = true;
                invincibleTimer = timeInvincible;
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);

        float pAmount = amount/100;

    }


    // Update is called once per frame
    void Update()
    {

        
        //some health bar stuff (worsks i think )

        healthBar.SendMessage("HealthSetter", currentHealth);


        float pHealth = currentHealth/maxHealth;

       
        //can see if you interacted w the stranger guy. doesnt do anything exept in log
        if(Input.GetKeyDown(KeyCode.Q))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidBody2d.position + Vector2.up * 0.2f, lookDirection, 2.0f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                Debug.Log("Raycast has hit the object " + hit.collider.gameObject);

            }
        }

         if (isInvincible)//invincibiklity 
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        //healthBar.HealthSetter(health);

        
        
        if (currentHealth < 1) //kills pplayer if its dead
        {
            Destroy(gameObject);
            
        }

        void Launch()
        {
            GameObject projectileOb = Instantiate(projectilePrefab, rigidBody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            Projectile projectile = projectileOb.GetComponent<Projectile>();
            projectile.Launch(lookDirection, launchSpeed); //projectile maker

        
        } 

        if(Input.GetKeyDown(KeyCode.E))//projectile
        {
            int i = proj;
            while(i > 0)
            { 
             Launch();
             i--;

             new WaitForSeconds(1); //makes it more powerful for some reason???

            }
        }


    }

    void FixedUpdate()
    {
         float horizontal = Input.GetAxis("Horizontal");
         float rotation = rigidBody2d.rotation;

        if (horizontal < 0) // some rotation stuff (ew) PUT ANYTHING ROTATIONY HERE
        {//left
            lookDirection = new Vector2(-1,0);
            transform.rotation = Quaternion.Euler(0,180,0);
            
            
            //
        }
        else if (horizontal > 0)
        {//right
            lookDirection = new Vector2(1,0);
                        transform.rotation = Quaternion.Euler(0,0,0);

        }

        float vert = Input.GetAxis("Vertical");

        //moving
        
        Vector2 position = transform.position;
        position.x = position.x + spd * horizontal * Time.deltaTime;
        position.y = position.y + spd * vert * Time.deltaTime;

        rigidBody2d.MovePosition(position);
    }
    

    




}