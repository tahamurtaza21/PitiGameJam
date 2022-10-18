using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaStuffMovement : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField]
    float moveSpeed = 5f;

    Spawner spawner;

    bool moveRight = false;
    bool moveLeft = false;
    

    // Start is called before the first frame update
    void Awake()
    {
        spawner = FindObjectOfType<Spawner>();
        rb2d = GetComponent<Rigidbody2D>();

        WhichDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }


    void WhichDirection()
    {
        if(transform.position.x > 0)
        {
            moveLeft = true;
        }
        else
        {
            moveRight = true;
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
        }
    }

    void Move()
    {
        if(moveLeft)
        {
            rb2d.velocity = Vector2.left * moveSpeed * Time.deltaTime;
            
            //rb2d.DOMove(Vector2.left * moveSpeed * Time.deltaTime, 10f);

            //transform.DOShakeScale(10f, new Vector3(0, 0.4f, 0f));
            
        }
        else if(moveRight)
        {
            rb2d.velocity = Vector2.right * moveSpeed * Time.deltaTime;

            //rb2d.DOMove(Vector2.right * moveSpeed * Time.deltaTime, 10f);

            //transform.DOShakeScale(10f, new Vector3(0, 0.4f, 0f));    
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        spawner.objectsInScene--;
    }
}
    