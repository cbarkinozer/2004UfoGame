using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    public float JumpVelocity;
    Rigidbody2D rb;
   public float VelocityX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        
       
        
            Vector2 Velocity = rb.velocity;
            Velocity.x = movement.x * VelocityX;
            rb.velocity = Velocity;
        
     /*   else
        {
            transform.position += movement * Time.deltaTime * (moveSpeed-10f);
        }
        */
    }
void Jump()
    {
        if (Input.GetButtonDown("Jump")&& isGrounded == true) {

            rb.velocity = new Vector2(0, JumpVelocity);
            isGrounded = false;
        }
        
    }
}
