using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody2D _rigRigidbody2D;
    private PlayerDialogue _playerDialogue;
    private PlayerHide _playerHide;
    private float _xVelocity = 0f;
    private float _yVelocity = 0f;
    public float speed = 3;
    private const string finishTag = "Finish";
    private const string escapeTag = "Escape";
    private const string rushTag = "Rush";
    public string scaryLevel = "BackDoor";
    public string realLevel = "FirstLevel";
    public string rushJumpscare = "RushJumpscare";
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
