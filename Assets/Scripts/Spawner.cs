using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject Fishes;
    [SerializeField] GameObject Shark;

    [SerializeField] Transform Left;
    [SerializeField] Transform Right;


    [SerializeField] int maxNumofobjects = 8;
    public int objectsInScene = 0;

    [Header("General")]
    [SerializeField] float timeBtwSpawn = 0.75f;
    [SerializeField] float startTimeBtwSpawn = 1.25f;
    [SerializeField] float decreaseTime = 0.02f;
    [SerializeField] float minTime = 1.05f;

    void Update()
    {
        Add();
    }

    void Add()
    {
        if (objectsInScene < maxNumofobjects && timeBtwSpawn <= 0)
        {

            Transform Where = LeftOrRight();

            Vector3 randomPoint = new Vector3(Where.position.x,
                
                Random.Range(-(Where.GetComponent<BoxCollider2D>().bounds.extents.y - Where.GetComponent<BoxCollider2D>().bounds.center.y), // Get Random Value in Y
                Where.GetComponent<BoxCollider2D>().bounds.extents.y + Where.GetComponent<BoxCollider2D>().bounds.center.y),
                
                Where.position.z);


            GameObject instantiatedobstacle = Instantiate(SharkOrFishes(), randomPoint, Quaternion.identity.normalized);

            timeBtwSpawn = startTimeBtwSpawn;

            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }

            objectsInScene++;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

    Transform LeftOrRight()
    {
        int randomNumber = Random.Range(0,10);
        
        if(randomNumber > 4)
        {
            return Left;
        }
        else
        {
            return Right;
        }   
    }

    GameObject SharkOrFishes()
    {
        int randomNumber = Random.Range(0, 10);

        if (randomNumber > 1)
        {
            return Fishes;
        }
        else
        {
            return Shark;
        }
    }

}
