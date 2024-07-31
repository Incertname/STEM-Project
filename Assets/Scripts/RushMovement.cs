using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushMovement : MonoBehaviour
{
    private Rigidbody2D RushBody2;
    // Start is called before the first frame update
    void Start()
    {
        RushBody2 = GetComponent<Rigidbody2D>();
        RushBody2.velocity = new Vector2(0f, -15f);
    }

    // Update is called once per frame
    void Update()
    {
        
        

        
    }
}
