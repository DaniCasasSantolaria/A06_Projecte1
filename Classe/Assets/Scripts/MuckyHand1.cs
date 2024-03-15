using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuckyHand1 : MonoBehaviour
{
    /* private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.transform.CompareTag("Player"))
         {
             Debug.Log("Player Damaged"); 
             //Destroy(collision.gameObject);
         }
     }*/ //CODI DELS PINCHOS!!!!!!!!!!
    [SerializeField] public Transform player;
    [SerializeField] private float distance;
    public Vector3 puntoInicial;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        {
            animator = GetComponent<Animator>();
            puntoInicial = transform.position;
            spriteRenderer = GetComponent<SpriteRenderer>();    
        }
    }

    private void Update()
    {   
     distance = Vector2.Distance(transform.position, player.position);
     animator.SetFloat("Distance", distance);   
    }

    public void Girar(Vector3 objetivo)
    {
        if (transform.position.x < objetivo.x)
        {
            spriteRenderer.flipX = true;
        } 

        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");
            Destroy(collision.gameObject);
        }
    }


}
