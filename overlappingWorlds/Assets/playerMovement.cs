using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    

    [Header("Movement Values")]
    [SerializeField] private float MaxMoveSpeed;
    [SerializeField] private float MovementAcceleration;
    [SerializeField] private float MovementDecceleration;
    
    [Header("Jump Values")]
    public float JumpPower;
    public float airFallMultiplier;
    public float aireLinearDrag;


    private float Horizontal;
    private bool isChangingDirections =>(rb.velocity.x >0f && Horizontal<0f) || (rb.velocity.x <0f && Horizontal>0f); 
    public bool isFacingRight;

    

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        movement();
        
        fallFaster();
        if(isGrounded())
        {
            applyDrag();
        }
        else
        {
            applyAirDrag();
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position,0.2f,GroundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x*=-1;
        transform.localScale = scale;
        
    }

    private void Input(InputAction.CallbackContext context)
    {
        Horizontal = context.ReadValue<Vector2>().x;
    }

    private void movement()
    {
        rb.AddForce(new Vector2(Horizontal,0) * MovementAcceleration);

        if(Mathf.Abs(rb.velocity.x) > MaxMoveSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x)* MaxMoveSpeed, rb.velocity.y);
        }
        if(!isFacingRight && Horizontal > 0f ||isFacingRight && Horizontal < 0f)
        {
            Flip();
        }
    }

    private void applyDrag()
    {
        if(Mathf.Abs(Horizontal) < 0.4f|| isChangingDirections)
        {
            rb.drag = MovementDecceleration;
        }
        else
        {
            rb.drag = 0f;
        }
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x,JumpPower);
        }

        if(context.canceled && rb.velocity.y >0f)
        {
             rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y *0.5f);
        }

    }

    public void fallFaster()
    {
        if(rb.velocity.y <0f)
        {
            rb.gravityScale = airFallMultiplier;
        }
        else
        {
            rb.gravityScale = 1f;
        }
        
           
        
    }

    public void applyAirDrag()
    {
        rb.drag = aireLinearDrag;
    }
}
