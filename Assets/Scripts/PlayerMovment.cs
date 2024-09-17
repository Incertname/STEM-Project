using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody2D _rigRigidbody2D; // The actual Rigid Body Object
    private PlayerDialogue _playerDialogue; //Player Dialouge script
    private PlayerHide _playerHide; // Player Hide script
    private float _xVelocity = 0f; //X velocity
    private float _yVelocity = 0f; //Y velocity
    public float speed = 3; //Player Speed
    private const string finishTag = "Finish"; // tag for the collision of the door to the scary room
    private const string escapeTag = "Escape"; // tag for the collision of the exit of the scary room
    private const string rushTag = "Rush"; // tag for Rush's collision
    public string scaryLevel = "BackDoor"; // Tag for the actual scary level scene
    public string realLevel = "FirstLevel"; // tag for the main world scene
    public string rushJumpscare = "RushJumpscare"; // tag for the Rush Jumpscare scene
    public bool isCrouching = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        string colTag = col.tag;
            Debug.Log(colTag);
            switch (colTag)
            {
                case finishTag:
                {
                    Debug.Log("Finish");
                    SceneManager.LoadScene(scaryLevel);
                    return;
                }
                case escapeTag:
                {
                    Debug.Log("Escape");
                    SceneManager.LoadScene(realLevel);
                    return;
                }
                case rushTag:
                {
                    if (_playerHide.isHidden)
                    {
                        Debug.Log("Survived");
                    }
                    else
                    {
                        SceneManager.LoadScene(rushJumpscare);
                        Debug.Log("Dead");
                    }
                    return;
                }
            }
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigRigidbody2D = GetComponent<Rigidbody2D>();
        _playerDialogue = GetComponent<PlayerDialogue>();    
        _playerHide = GetComponent<PlayerHide>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching;
            speed = (isCrouching? 4:12);
        }
        if (_playerDialogue.IsSpeaking() | _playerHide.isHidden)
        {
            _xVelocity = 0;
            _yVelocity = 0;
        }
        else
        {
            _xVelocity = Input.GetAxis(Structs.Input.horizontal);
            _yVelocity = Input.GetAxis(Structs.Input.vertical);
        }

        
        _rigRigidbody2D.velocity = new Vector2(_xVelocity, _yVelocity) * speed; 
    }
}
