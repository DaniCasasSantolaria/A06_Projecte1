using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class LevelColider : MonoBehaviour
{
    private int level;
    private bool Level1 = false;
    private bool Level2 = false;
    private bool Level3 = false;
    private bool Level4 = false;
    private PolygonCollider2D polygonCollider;
    private Collision2D collision2D;
   
    // Start is called before the first frame update
    void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.collider.CompareTag("Nivel1"))
        {
            level = 1;
            //SceneManager.LoadScene(level);
            Debug.Log("Nivel 1");
        }
        else if (collision2D.collider.CompareTag("Nivel2"))
        {
            level = 2;
            //SceneManager.LoadScene(level);
            Debug.Log("Nivel 2");

        }
        else if (collision2D.collider.CompareTag("Nivel3"))
        {
            level = 3;
            //SceneManager.LoadScene(level);
            Debug.Log("Nivel 3");

        }
        else if (collision2D.collider.CompareTag("Nivel4"))
        {
            level = 4;
            // SceneManager.LoadScene(level);
            Debug.Log("Nivel 4");

        }
    }
    


    
}

