using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_chase_2 : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public float range = 10.0f;
    public int health = 2;
    public int damage = -5;
    
    
    private GameObject player;


    private Rigidbody2D rb;
    private Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction= player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        direction.Normalize();
        movement = direction;

        if (health < 1)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
       player = GameObject.FindGameObjectWithTag("Player");

     float distance = Vector2.Distance(transform.position, player.transform.position);
     //distance is what bw player and thign 
     if (distance < range)
        {
             moveCharacter(movement);

        }

    }


    void moveCharacter(Vector2 direction)
    {
        Vector2 pos = (Vector2)transform.position + (direction * moveSpeed * Time.deltaTime);
        rb.MovePosition(pos);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        move2D player = other.gameObject.GetComponent<move2D>();

        if (player != null)
        {
            player.ChangeHealth(damage);
        }
    }

    void ChangeHealth(int amountChanged)
    {
        health = health + amountChanged;
    }
}
