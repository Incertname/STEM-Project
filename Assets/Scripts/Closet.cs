using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite hideSprite;
    public Sprite seekSprite;
    private GameObject _talkIcon;
    void ClosetHide(bool playerHiding)
    {
        if (playerHiding)
        {
            spriteRenderer.sprite = hideSprite;
        }
        else
        {
            spriteRenderer.sprite = seekSprite;
        }
        
    }
    private void OnEnable()
    {
        PlayerHide.actionHide += ClosetHide;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        _talkIcon = transform.Find(Structs.GameObjects.talkIcon).gameObject;
        _talkIcon.SetActive(false);
        
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Structs.Tags.playerTag)
        {
            _talkIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Structs.Tags.playerTag)
        {
            _talkIcon.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
