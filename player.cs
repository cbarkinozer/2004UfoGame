using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    
     //1-dinamikleştirmek  
     //2-joystick
     //3-görseller
     //4-animasyon




    //joystick

    private void FixedUpdate()
    {
       // GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
       // Camera.main.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
      
    }

  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("down");
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -7.5f);

            Debug.Log("giriyon mu la");
        }

    }

}
