using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RushJumpscare : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite screamSprite;
    public float timer = 0; // Timer to time the parts of the jumpscare
    private bool isVisible = false; //Boolian to store whether the first part (Rush becomes visible) has happened to avoid repeting it
    private bool isScaled = false; //Same as above but for the next step, scaling him up slightly
    private bool isScreaming = false; //Same as above but for the actual scream
    public string scaryLevel = "BackDoor"; //Gets the name of the scene to send you back there

    private AudioSource _speaker;
    private bool isPlaying = false;
    [SerializeField] AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        _speaker = GetComponent<AudioSource>();
        
    }
    public void ChangeTheSound(int clipIndex) // the index of the sound, 0 for first sound, 1 for the 2nd..etc     
    {         // use one desired logic         // this will make only one sound to play without interruption     
    _speaker.Pause();    
    _speaker.clip = clips[clipIndex];         
    _speaker.Play();          // this will make multiple sound to play with interruption         
    _speaker.PlayOneShot(clips[clipIndex]);     }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ((timer >= 3) && (!isVisible))
        {
            spriteRenderer.color = new Color(255f, 255f, 255f, 255f);
            isVisible = true;
        }
        if ((timer >= 8) && (!isScaled))
        {
            transform.localScale = new Vector3(1.4f,1.4f,1f);
            isScaled = true;
        }
        if ((timer >= 12) && (!isScreaming))
        {
            spriteRenderer.GetComponent<Animator>().Play("Base Layer.RushJumpscare");
            Camera.main.GetComponent<Animator>().Play("Base Layer.CameraJumpscare");
            isScreaming = true;
            ChangeTheSound(1);
        }
        if (timer >= 15)
        {
            SceneManager.LoadScene(scaryLevel);
        }
    }
}
