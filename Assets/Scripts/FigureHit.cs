using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FigureHit : MonoBehaviour
{
    private Rigidbody2D _rigRigidbody2D; // The actual Rigid Body Object
    private string targetTag = "Noise";
    private const string soundTag = "Noise";
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        string colTag = col.tag;
        Debug.Log(colTag);
        //Debug.Log("Collided");
        //Debug.Log(colTag == soundTag);
        //Debug.Log(soundTag);


        if (colTag == targetTag)
        {
            GetComponent<AIDestinationSetter>().enabled = false;
            GetComponent<AIBase>().maxSpeed = 10;
        }
        switch (colTag)
        {
            case soundTag:
            {
                
                //GetComponent<AIDestinationSetter>().enabled = false;
                //GetComponent<AIBase>().maxSpeed = 10;
                return;
            }
        }
    }
                    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetTag = GetComponent<AIDestinationSetter>().target.tag;
    }
}
