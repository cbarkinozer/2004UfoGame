using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    [SerializeField] Text text;
    private GameObject CreatedBirdObject;
    [SerializeField] GameObject WhiteBird;
    [SerializeField] GameObject DarkBird;
    [SerializeField]float birdVelocity ;
     GameObject Parent;
    //dinamiklestirmek icin
    private Vector2 DynamiCamera;
    private  Vector2 CameraPosition;
    float Ymax, Ymin;
    float Xmax, Xmin;
    void Start()
    {
        
        Parent = new GameObject();
        Parent.name = "BirdParent";
        DynamiCamera = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.transform.localScale.x, Camera.main.transform.localScale.y));
        Xmax= (Mathf.Abs(DynamiCamera.x) + 2.0f);
        Xmin = ((DynamiCamera.x - 2.0f));
       
        StartCoroutine(BirdSpawn());
        
    }
    private void Update()
    { float Fps = 1 / Time.deltaTime;
        text.text = "fps: "+Fps.ToString();


        CameraPosition = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
        Parent.transform.position = CameraPosition;// ne olur ne olmaz olası guve diye
        Ymax = (Mathf.Abs(DynamiCamera.y) + 1.0f + CameraPosition.y);
        Ymin = (DynamiCamera.y + 1.0f + CameraPosition.y);

        

        // yok etme 
        foreach (Transform bird in Parent.transform)
        {
            if (bird.position.x < (Xmin-1.0f) || bird.position.x > (Xmax+1.0f)|| bird.position.y<(Ymin-3.0f))
                    Destroy(bird.gameObject);

        }
     /* 
      * debug durumlari kalsin
        Debug.Log("Y EKSENİ MİN:" + DynamiCamera.y + 1.0f + CameraPosition.y);
        Debug.Log("Y EKSENİ MAX: " + Mathf.Abs(DynamiCamera.y) + 1.0f + CameraPosition.y);
        Debug.Log("X EKSENİ MİN " + (DynamiCamera.x - 2.0f));
        Debug.Log("X EKSENİ MAX" + (Mathf.Abs(DynamiCamera.x) + 2.0f));
        Debug.Log("camera transfor position Y:" + CameraPosition.y);
       */
    }
    IEnumerator BirdSpawn(){
        //simdilik true  bir şeye bağlıyacağız
        while (true)
        {
            

            float rnd = Random.Range(0, 2);
            EnemyCreat((rnd == 0) ? WhiteBird : DarkBird);
       
            // bu da bir şeye bağlanacak
            yield return new  WaitForSeconds(Random.Range(0.50f,0.65f));// belli bir siklige ayarlnacak 

        }
    }
   
   void EnemyCreat(GameObject Bird)
    {
       
        
        // dinamiklestirildi

        float Y = Random.Range(Ymin, Ymax);
        int random = Random.Range(0, 3);
        float X = (random == 0) ? (Xmin) :(Xmax);
        Vector3 BirdPosition = new Vector3(X, Y, Bird.transform.position.z);
        CreatedBirdObject = Instantiate(Bird, BirdPosition, Quaternion.identity) as GameObject;

        if (random == 0) {
            CreatedBirdObject.GetComponent<SpriteRenderer>().flipX = true;
            CreatedBirdObject.GetComponent<Rigidbody2D>().velocity = new Vector2(birdVelocity, 0);

        }
        else CreatedBirdObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-birdVelocity, 0);
        CreatedBirdObject.transform.parent = Parent.transform;

    }
    public Vector2 DynamicXandY(bool MaxValue)
    {

        if (MaxValue == true) return new Vector2(Xmax, Ymax);
        else return new Vector2(Xmin, Ymin);

    }

   


}
