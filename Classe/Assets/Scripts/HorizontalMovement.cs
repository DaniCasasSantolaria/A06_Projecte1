using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    private float movementSpeed = 3.5f;
    private Rigidbody2D rB2D;
    private PolygonCollider2D polygonCollider;
    private float Horizontal;
    //Animator
    public Animator animator;
    private bool lookRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rB2D = GetComponent<Rigidbody2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }
    void PlayerMovement()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        rB2D.velocity = new Vector2(Horizontal * movementSpeed, rB2D.velocity.y);
        Debug.Log(Mathf.Abs(Horizontal));
      
        if(Input.GetButtonDown(KeyCode.a))
            animator.SetBool("keyboardMovementPressed", true);
        else if(Input.GetButtonDown("right") == true)
            animator.SetBool("keyboardMovementPressed", true);
        else
            animator.SetBool("keyboardMovementPressed", false);
        animator.SetFloat("Speed", Mathf.Abs(Horizontal));
        PlayerOrientation(Horizontal);
        
        
    }

    void PlayerOrientation(float Horizontal)
    {
        if ((lookRight == true && Horizontal < 0) || (lookRight == false && Horizontal > 0))
        {
            lookRight = !lookRight; //Para negar el valor
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
