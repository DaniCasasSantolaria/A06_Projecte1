using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float movementSpeed = 3.5f;
    public float jumpForce = 100.0f;
    private Rigidbody2D rB2D;
    private float Horizontal;
    private float Vertical;
    private bool lookRight = true;

    // Start is called before the first frame update
    void Start(){
        rB2D = GetComponent<Rigidbody2D>();
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
    }

    void PlayerMovement()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");   //FALTA ACABAR SALTO
        rB2D.velocity = new Vector2(Horizontal * movementSpeed, Vertical * jumpForce);
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