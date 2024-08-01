using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushMovement : MonoBehaviour
{
    private Rigidbody2D RushBody2;
    Transform _player_transform;
    // Start is called before the first frame update
    void Start()
    {
        RushBody2 = GetComponent<Rigidbody2D>();
        RushBody2.velocity = new Vector2(0f, -15f);
        _player_transform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        RushBody2.position = new Vector2(_player_transform.position.x,RushBody2.position.y);
        if (RushBody2.position.y < -1500f)
        {
            Destroy(gameObject);
        }
        

        
    }
}
