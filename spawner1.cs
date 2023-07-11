using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner1 : MonoBehaviour
{
    public GameObject enemy;
    public float timerP = 30;
    
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timerP)
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        Instantiate(enemy, this.transform.position, transform.rotation);
    }
}
