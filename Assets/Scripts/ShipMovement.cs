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
        LimitRotation();
    }

    void FixedUpdate()
    {
        Move(Input.GetAxis("Horizontal"));
    }


    void Move(float direction)
    {
        rb2D.velocity = new Vector2(moveSpeed * direction * Time.deltaTime, 0f);
    }

    void LimitRotation()
    {
        // Limits Rotation properly 

        Quaternion updatedRotation = transform.localRotation;

        float zRotation = Mathf.Clamp(transform.localRotation.z, Mathf.Deg2Rad * -10f, Mathf.Deg2Rad * 10f);
        updatedRotation.z = zRotation;

        transform.rotation = updatedRotation;

        //Debug.Log(updatedRotation);
    }
}
