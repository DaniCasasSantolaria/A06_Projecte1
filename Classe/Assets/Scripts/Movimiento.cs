using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Rigidbody2D rB2D = null; //S'ha de fer privada

    public float movementSpeed = 5.0f;
    public float jumpForce = 100.0f;

    // Start is called before the first frame update
    void Start(){
        rB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        float horizontalMovement = Input.GetAxis("Horizontal");
        Debug.Log($"El valor horitzontal es {horizontalMovement}"); //Per a la consola
        if(rB2D != null)
        {
            rB2D.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, rB2D.velocity.y);
        }

        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, movementSpeed));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -movementSpeed));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(movementSpeed, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-movementSpeed, 0));
        }*/
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, movementSpeed));
        }
    }
}