using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibleHealth : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        move2D controller = other.GetComponent<move2D>();
        
        if (controller != null)
        {
            
            controller.ChangeHealth(10);
            Destroy(gameObject);
            
        }
    }
}
