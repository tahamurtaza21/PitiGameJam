using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaStuffMovement : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField]
    public float moveSpeed = 50f;

    [SerializeField] float value;

    Spawner spawner;

    bool moveRight = false;
    bool moveLeft = false;

    Vector2 netVelocity = Vector2.zero;
    bool moveAway = false;
    public bool isDifficultFish;
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
        MoveAway();
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

    public float GetValue()
    {
        return value;
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Net")
        {
            netVelocity = collision.gameObject.GetComponentInParent<Rigidbody2D>().velocity;
            moveAway = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveAway = false;
    }

    void MoveAway()
    {
        if(moveAway == true && isDifficultFish)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x * 1.4f, netVelocity.y * 0.6f); 
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        spawner.objectsInScene--;
    }
}
    