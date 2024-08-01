using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushSpawner : MonoBehaviour
{
    private Transform RushSpawner2;
    public GameObject preFab;

    public float cooldown = 30;
    // Start is called before the first frame update
    void Start()
    {
        RushSpawner2 = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            GameObject rush = Instantiate(preFab,RushSpawner2.position,Quaternion.identity);
            cooldown = Random.Range(25, 60);
        }
        
    }
}
