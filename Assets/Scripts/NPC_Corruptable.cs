using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CorruptableNPC : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public List<string> dialogue = new List<string>();
    public List<string> corrupt_dialogue = new List<string>();
    private GameObject _talkIcon;
    private bool isCorrupt = false;

    private void Start()
    {
        _talkIcon = transform.Find(Structs.GameObjects.talkIcon).gameObject;
        _talkIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Structs.Tags.playerTag)
        {
            _talkIcon.SetActive(true);
            collision.GetComponent<PlayerDialogue>().CopyDialogue(dialogue);
            collision.GetComponent<PlayerDialogue>().SetCanSpeak(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Structs.Tags.playerTag)
        {
            _talkIcon.SetActive(false);
            collision.GetComponent<PlayerDialogue>().SetCanSpeak(false);
        }
    }
    void Update()
    {
        if ((GameObject.Find("Player").GetComponent<PlayerDialogue>().isCorrupt) && ! isCorrupt) 
        {
            dialogue = corrupt_dialogue;
//            dialogue = new List<string>(){"I'm evil now", "hahahaha"};
            spriteRenderer.sprite = newSprite;
            isCorrupt = true;
        }
    }

}
