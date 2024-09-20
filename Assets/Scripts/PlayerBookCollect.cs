using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBookCollect : MonoBehaviour
{
    public int books = 0;
    public bool canCollect = false;
    public string bookTag = "Book";
    public GameObject _libMap;
    public string realLevel = "FirstLevel";
    private const string trueEscapeTag = "Escape2";
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        string colTag = col.tag;
        if (col.tag == bookTag)
        {
            canCollect = true;
        }
        if ((col.tag == trueEscapeTag) && (books >= 8))
        {
            SceneManager.LoadScene(realLevel);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        string colTag = col.tag;
        if (col.tag == bookTag)
        {
            canCollect = false;
        }
    }
    public void CollectBook()
    {
        books++;
            canCollect = false;
            _libMap.GetComponent<FigurePathLoader>().FigureAggro();
            Debug.Log("Figure Aggro Book");
    }
    void Start()
    {
        _libMap = GameObject.Find("Library Map");
    }

    // Update is called once per frame
    void Update()
    {
//        if (canCollect && Input.GetKeyDown(KeyCode.E))
//        {
//            
//        }
        
    }
}
