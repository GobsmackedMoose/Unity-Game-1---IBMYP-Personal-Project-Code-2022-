using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage1 : MonoBehaviour
{
     void OnTriggerStay2D(Collider2D other)
    {
        move2D controller = other.GetComponent<move2D>();
        
        if (controller != null)
        {
            
            controller.ChangeHealth(-1);
            
        }
    }
}
