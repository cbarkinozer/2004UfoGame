using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystick : MonoBehaviour
{
    public Transform player_;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 PointA;
    private Vector2 PointB;
    public Transform Circle;
    public Transform OtherCircle;

    void Start()
    {
    
    }

    void Update()
    {
        Vector2 camera = Camera.main.transform.position;


        if (Input.GetMouseButtonDown(0))// ekrana click yaoılınca
        {

            PointA = CameraRealWorld(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z)*-1;
            Circle.transform.position = PointA * -1;
            OtherCircle.transform.position = PointA * -1;
            Circle.GetComponent<SpriteRenderer>().enabled = true;
            OtherCircle.GetComponent<SpriteRenderer>().enabled = true;

        }
        if (Input.GetMouseButton(0))// BASILI KALDIĞINI TUTUYOR
        {
            touchStart = true;
            PointB = CameraRealWorld(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z)*-1;


        }else
        {
            touchStart = false;
        }


       // MoveCharacter(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))); // bu tuslaral olan icin
    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 Offset = PointB - PointA;
            Vector2 direction = Vector2.ClampMagnitude(Offset, 1);
            MoveCharacter(direction*-1);// I dont know why
            Circle.transform.position = new Vector2(PointA.x + direction.x, PointA.y + direction.y) * -1;

        }
        else
        {

            Circle.GetComponent<SpriteRenderer>().enabled =false;
            OtherCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void MoveCharacter(Vector2 Direction)
    {
        player_.Translate(Direction * speed * Time.deltaTime);



    }
    Vector3 CameraRealWorld(float x, float y,float z)
    {
        Vector3 RealCamera = Camera.main.ScreenToWorldPoint(new Vector3(x, y,z));
        return RealCamera;


    }

}
