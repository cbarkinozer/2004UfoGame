using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("down");
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -7.5f);

            Debug.Log("giriyon mu la");
        }

    }

}
