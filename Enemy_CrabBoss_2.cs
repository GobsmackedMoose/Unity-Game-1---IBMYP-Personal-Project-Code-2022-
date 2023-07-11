using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CrabBoss_2 : MonoBehaviour
{
    public float moveSpeed = 5.0f;


    public float range = 10.0f;
    public int Maxhealth = 20;
    public int meleeDamage = -10;

    public GameObject crabBullet;
    public Transform crabBulletPos;

    public GameObject healthBarCrab;

    private int health;
     
    private GameObject player;

    private float timer;

    private Rigidbody2D rb;
    private Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        health = Maxhealth;
        rb = this.GetComponent<Rigidbody2D>();
                         healthBarCrab.SendMessage("MaxHealthSetter", Maxhealth);

    }

    // Update is called once per frame
    void Update()
    {
     player = GameObject.FindGameObjectWithTag("Player");
        
        //faces player, idk what direction is its fromo a tutorial. 
        Vector3 direction= player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        moveDir = direction;

        healthBarCrab.SendMessage("currentHealthSetter", health);


        //for shooting.
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


        //health stuffs
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
         player = GameObject.FindGameObjectWithTag("Player");

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < range)
        {
             moveCharacter(moveDir);

        }
 
    }

    void moveCharacter(Vector2 direction)
    {
        Vector2 pos = (Vector2)transform.position + (direction * moveSpeed * Time.deltaTime);
        rb.MovePosition(pos);
    }

    void OnCollisionEnter2D(Collision2D other) //if it hits player  
    {
        move2D player = other.gameObject.GetComponent<move2D>();
         if (player != null)
        {
            player.ChangeHealth(meleeDamage);
        }
    }

    void ChangeHealth(int amountChanged)
    {
        health = health + amountChanged;
    }

    void shoot()
    {
        Instantiate(crabBullet, crabBulletPos.position, Quaternion.identity);
    }
}
