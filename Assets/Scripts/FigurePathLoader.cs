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
    public void FigureAggro()
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
        _figure.GetComponent<FigureHit>().ChangeTheSound(1);
    }
    void FigureAggroCloset(bool playerHiding)
    {
        FigureAggro();
    }
    private void OnEnable()
    {
        PlayerHide.actionHide += FigureAggroCloset;
    }
    // Update is called once per frame
    void Update()
    {
        if ((! _player.GetComponent<PlayerMovment>().isCrouching) && (_player.GetComponent<Rigidbody2D>().velocity != new Vector2(0,0)))
        {
            FigureAggro();
        }

        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(_figure.transform.position, (_player.transform.position - _figure.transform.position),5,LayerMask.GetMask("Player","Obstacles"));
        Debug.DrawRay(_figure.transform.position, (_player.transform.position - _figure.transform.position) * (5 / Vector3.Distance(_player.transform.position,_figure.transform.position)),Color.red);
        //Debug.Log(Vector3.Distance(_player.transform.position,_figure.transform.position));
        // If it hits something...
        if (hit.collider != null)
        {
            Debug.Log(hit.collider);
            if ((hit.collider.tag == "Player") && !(_player.GetComponent<PlayerHide>().isHidden))
            {
                _figure.GetComponent<AIDestinationSetter>().target = _player.transform;
                FigureAggro();
            }
        }
        else
            {
                _figure.GetComponent<AIDestinationSetter>().target = noiseLocation.transform;
            }
    


    }
}
