using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private float movementSpeed = 3.5f;
    private float jumpForce = 15.0f;
    private Rigidbody2D rB2D;
    private PolygonCollider2D polygonCollider;
    private float Horizontal;
    private bool lookRight = true;
    public LayerMask layerSuelo;
    //[Header ("Wall Jumps System")]
    //public Transform wallCheck;
    //bool isWallTouch;
    //bool isSliding;
    //public float wallSlidingSpeed;

    // Start is called before the first frame update
    void Start(){
        rB2D = GetComponent<Rigidbody2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update(){
        PlayerMovement();
        PlayerJump();
        //isWallTouch = Physics2D.OverlapBox(wallCheck.position, new Vector2(0.05f, 0.45f), 0, layerSuelo);
    }
    bool CharacterInGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(polygonCollider.bounds.center, new Vector2(polygonCollider.bounds.size.x, polygonCollider.bounds.size.y), 0f , Vector2.down, 0.2f, layerSuelo); //(Punto de Origen, (Vector) Tama�o de la caja, �ngulo, Direcci�n, Distancia, Mascara de capas)
        //Si hay colision raycastHit.collider = Objeto, si no hay colision raycastHit.collider = null
        return raycastHit.collider != null;
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CharacterInGround())
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