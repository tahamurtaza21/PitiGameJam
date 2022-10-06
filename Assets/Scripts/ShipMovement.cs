using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    Rigidbody2D rb2D;

    [SerializeField] float moveSpeed = 5f;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        Move(Input.GetAxisRaw("Horizontal"));
    }

    void Move(float direction)
    {
        rb2D.velocity = new Vector2(moveSpeed * direction * Time.deltaTime, 0f);
    }

    void OutOfBounds()
    {

    }
}
