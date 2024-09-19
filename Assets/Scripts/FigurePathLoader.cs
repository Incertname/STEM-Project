using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FigurePathLoader : MonoBehaviour
{
    private AudioSource _speaker;
    public GameObject noiseLocation;
    public GameObject _player;
    public GameObject _figure;
    public double time_passed = 0.0;
    
    // Start is called before the first frame update
    void Start()
    {
        _speaker = GetComponent<AudioSource>();
        noiseLocation = GameObject.Find("NoiseLocation");
        _player = GameObject.Find("Player");
        _figure = GameObject.Find("Figure");
    }

    // Update is called once per frame
    void Update()
    {
        if ((! _player.GetComponent<PlayerMovment>().isCrouching) && (_player.GetComponent<Rigidbody2D>().velocity != new Vector2(0,0)))
        {
            if (_figure.GetComponent<AIDestinationSetter>().enabled == false)
            {
                _speaker.Play();
            }
            noiseLocation.transform.position = _player.transform.position;
            _figure.GetComponent<AIDestinationSetter>().enabled = true;
            _figure.GetComponent<AIBase>().maxSpeed = 20;
            
            while (time_passed <= 8.0)
            {
                time_passed += Time.deltaTime;
            }
            //_figure.GetComponent<AIDestinationSetter>().enabled = false;
            if (time_passed >= 8.0)
            {
                time_passed = 0.0;
            }
        }
    }
}
