using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_ENemy_1 : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    public float v;

    public int damage;

    public float changeTime = 3.0f;
    float timer;

    void Awake()
    {
        timer = changeTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * v;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot + 180);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * v;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot + 180);
        
         timer -= Time.deltaTime;

        if (timer < 0)
        {
            Destroy(gameObject);

        }
        
    }

     void OnCollisionEnter2D(Collision2D other)
    {
        move2D player = other.gameObject.GetComponent<move2D>();

        if (player != null)
        {
            player.ChangeHealth(damage * -1);
            Destroy(gameObject);
        }
    }
}
