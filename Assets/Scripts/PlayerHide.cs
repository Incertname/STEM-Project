using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    public bool canHide = false;
    public bool isHidden = false;
    public delegate void ActionHide(bool playerHiding);
    public static ActionHide actionHide;
    public SpriteRenderer spriteRenderer;
    void OnTriggerEnter2D(Collider2D col)
    {
        string colTag = col.tag;
        if (colTag == "Closet")
        {
            Debug.Log("Can hide");
            canHide = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        string colTag = col.tag;
        if (colTag == "Closet")
        {
            Debug.Log("Cant hide");
            canHide = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canHide && Input.GetKeyDown(KeyCode.E))
        {
            if (isHidden)
            {
                isHidden = false;
                spriteRenderer.color = new Color(255f, 255f, 255f, 255f);
                actionHide(false);
            }
            else
            {
                isHidden = true;
                spriteRenderer.color = new Color(255f, 255f, 255f, 0f);
                actionHide(true);
            }
        }
        
    }
}
