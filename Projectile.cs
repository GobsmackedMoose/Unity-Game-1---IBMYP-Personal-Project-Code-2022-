using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

        public float changeTime = 3.0f;
    float timer;

    Rigidbody2D rigidbody2d; 
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
         timer = changeTime;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Destroy(gameObject);

        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);

    }
    void OnCollisionEnter2D(Collision2D collision)// Collision2D is a method so type the name of the collision after it to use later 
{

    if (collision.gameObject.tag == "Enemy") 
        {
            Debug.Log("Projectile Collision with " + collision.gameObject); //collision.gameObject is example of it being used
            collision.gameObject.SendMessage("ChangeHealth", -1);
        }
 Destroy(gameObject);

}
}
