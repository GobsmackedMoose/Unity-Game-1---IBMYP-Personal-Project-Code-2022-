using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_chase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float range;


    Rigidbody2D rigidbody2D;
    
    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        

            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);




        

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        move2D player = other.gameObject.GetComponent<move2D>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
