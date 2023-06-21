using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 15f;
    [SerializeField] float jumpSpeed = 10f;

    Vector2 moveInput; //vecotr 2 because we have x and y in the 2d space
    Rigidbody2D myrigidbody;
    BoxCollider2D myBoxCollider;
    

    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnJump(InputValue value)
    {
        if(!myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if(value.isPressed)
        {
            myrigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myrigidbody.velocity.y); //(moveInput.x,move.Input.y)
        myrigidbody.velocity = playerVelocity;//to add velocity for gravity:
        /*Vector2 xyz = new Vector2(Input.GetAxisRaw("Horizontal"),0f);
        transform.Translate(xyz * runSpeed * Time.deltaTime);*/
        
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed){
            transform.localScale =new Vector2(Mathf.Sign(myrigidbody.velocity.x),1f);
        }
    }

}