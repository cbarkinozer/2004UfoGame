using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] GameObject WhiteBird;
    [SerializeField] GameObject DarkBird;
    [SerializeField]float birdVelocity ;

    void Start()
    {
        StartCoroutine(Spawn());

    }
    IEnumerator Spawn(){
        //simdilik true  bir şeye bağlıyacağız
        while (true)
        {
            float rnd = Random.Range(0, 2);
            EnemyCreat((rnd == 0) ? WhiteBird : DarkBird);

            Debug.Log("niye lan");
            // bu da bir şeye bağlanacak
            yield return new  WaitForSeconds(Random.Range(0.25f,0.30f));

        }
    }
   GameObject EnemyCreat(GameObject Bird)
    {
        // x ekseni +10 ile -10 arası , y ekseninde -5 ile +5 arası
        // burdaki değerler dinamikleşecek
        float Y= Random.Range(-4, 4);
        int random = Random.Range(0, 2);
        float X = (random == 0) ? (-10) : 10;
        Vector3 BirdPosition = new Vector3(X, Y, Bird.transform.position.z);
        GameObject CreatedObject = Instantiate(Bird, BirdPosition, Quaternion.identity) as GameObject;
        if (random == 0) {
            CreatedObject.GetComponent<SpriteRenderer>().flipX = true;
            CreatedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(birdVelocity, 0);

        }
        else CreatedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-birdVelocity, 0);

        return CreatedObject;

    }
}
