using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FigureHit : MonoBehaviour
{
    private Rigidbody2D _rigRigidbody2D; // The actual Rigid Body Object
    private string targetTag = "Noise";
    private const string soundTag = "Noise";
    private AudioSource _speaker;
    private bool isPlaying = false;
    [SerializeField] AudioClip[] clips;
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
            ChangeTheSound(0);
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
    public void ChangeTheSound(int clipIndex) // the index of the sound, 0 for first sound, 1 for the 2nd..etc     
    {         // use one desired logic         // this will make only one sound to play without interruption     
    _speaker.Pause();    
    _speaker.clip = clips[clipIndex];
    if (!_speaker.isPlaying)
    {
            _speaker.Play();          // this will make multiple sound to play with interruption   
    }       
      
    _speaker.PlayOneShot(clips[clipIndex]);     }
                    
    void Start()
    {
        _speaker = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        targetTag = GetComponent<AIDestinationSetter>().target.tag;
    }
}
