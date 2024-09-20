using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    private GameObject _talkIcon;
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
        if (_talkIcon.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
        }
    }
}
