using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] GameObject[] CloudObject;
    [SerializeField] float CloudVelocity;
    private GameObject CreatedCloudObject;
    private enemy EnemyScript;
    GameObject Parent;

    private void Start()
    {
        Parent = new GameObject();
        Parent.name = "CloudParent";
        
        EnemyScript = GetComponent<enemy>();
        StartCoroutine(CloudSpawn());
    }
    void Update()
    {

        foreach (Transform Cloudd in Parent.transform)
        {
            if (Cloudd.position.x < (EnemyScript.DynamicXandY(false).x - 1.0f) || Cloudd.position.x > (EnemyScript.DynamicXandY(true).x + 1.0f) ||
                Cloudd.position.y < (EnemyScript.DynamicXandY(false).y - 3.0f))
                Destroy(Cloudd.gameObject);

        }


    }
    IEnumerator CloudSpawn()
    {

        while (true)
        {


            int WhichOne = Random.Range(0, 3);

            CloudCreat(CloudObject[WhichOne]);

            yield return new WaitForSeconds(Random.Range(2.0f, 2.5f));



        }


        
    }

    void CloudCreat(GameObject Cloud)
    {

        float X = Random.Range(EnemyScript.DynamicXandY(false).x + 5, EnemyScript.DynamicXandY(true).x - 3);
        float Y = EnemyScript.DynamicXandY(true).y + 10;
        CreatedCloudObject = Instantiate(Cloud, new Vector2(X, Y), Quaternion.identity) as GameObject;
        CreatedCloudObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -CloudVelocity);
        CreatedCloudObject.transform.parent = Parent.transform;






    }
}
