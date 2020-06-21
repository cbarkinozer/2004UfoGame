using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    //1-dinamikleştirmek  
    //2-joystick
    //3-görseller
    //4-animasyon
    private void Update()
    {



    }
    private void FixedUpdate()
    {
    
      

    }

  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("down");
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -7.5f);

            
        }

    }

}
