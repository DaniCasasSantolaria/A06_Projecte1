using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private float movementSpeed = 3.5f;
    private float jumpForce = 13.0f;
    private Rigidbody2D rB2D;
    private BoxCollider2D boxCollider;
    private float Horizontal;
    private bool lookRight = true;

    // Start is called before the first frame update
    void Start(){
        rB2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update(){
        //Horizontal = Input.GetAxis("Horizontal");
        //Vertical = Input.GetAxis("Vertical");
        //Debug.Log($"El valor horitzontal es {Horizontal}"); //Per a la consola
        //rB2D.velocity = new Vector2(Horizontal, rB2D.velocity.y);

        //if (Input.GetKeyDown("Horizontal"))
        //{
        //    rB2D.AddForce(new Vector2(Horizontal * movementSpeed, Vertical));
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rB2D.AddForce(new Vector2(rB2D.velocity.x, rB2D.velocity.y * jumpForce));
        //}
        PlayerMovement();
        PlayerJump();
    }
    /*bool CharacterInGround()
    {
        //Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, ); Minuto 11:13. MAPA AMB TILEMAPS
    }*/

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rB2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void PlayerMovement()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        rB2D.velocity = new Vector2(Horizontal * movementSpeed, rB2D.velocity.y);
        PlayerOrientation(Horizontal);
    }

    void PlayerOrientation(float Horizontal)
    {
        if((lookRight == true && Horizontal < 0) || (lookRight == false && Horizontal > 0))
        {
            lookRight = !lookRight; //Para negar el valor
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}