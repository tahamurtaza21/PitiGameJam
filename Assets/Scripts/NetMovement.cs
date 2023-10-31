using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetMovement : MonoBehaviour
{

    SpringJoint2D anchor;

    [SerializeField]
    EdgeCollider2D netCollider;

    LineRenderer Rope;

    [SerializeField]
    GameObject Ship;

    [Header("Length Anchor")]
    [SerializeField]
    float alterLength = 0.0001f;
    float timeToAlterLength = 0.02f;
    float MaxLength = 8.0f;
    float MinLength = 0.8f;

    bool isHurt = false;

    void Awake()
    {
        Rope = GetComponent<LineRenderer>();
        anchor = GetComponent<SpringJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        NetUpAndDown();
        //LimitLength();
    }

    private void LateUpdate()
    {
        DrawRope();
    }


    private void NetUpAndDown()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.S))
        {
            //Debug.Log("True");
            StartCoroutine("MoveDown");
        }

        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine("MoveUp");

        }
    }

    IEnumerator MoveDown()
    {
        while ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.S)) && isHurt == false)
        {
            anchor.distance = Mathf.Clamp(anchor.distance + alterLength, MinLength, MaxLength);            
            yield return new WaitForSecondsRealtime(timeToAlterLength);
        }
        //netCollider.enabled = true;
    }

    IEnumerator MoveUp()
    {
        while ( (Input.GetMouseButton(1) || Input.GetKey(KeyCode.W) ) && isHurt == false)
        {
            anchor.distance = Mathf.Clamp(anchor.distance - alterLength, MinLength, MaxLength);            
            yield return new WaitForSecondsRealtime(timeToAlterLength);
        }
    }

    public IEnumerator Hurt()
    {
        while (anchor.distance > MinLength)
        {
            //Debug.Log(isHurt);
            isHurt = true;
            netCollider.enabled = false;
            if( (anchor.distance -= alterLength * 5) < MinLength)
            {
                anchor.distance = MinLength;
            }
            else
            {
                anchor.distance -= alterLength * 5;
            }
            

            yield return new WaitForSeconds(0.02f);
        }

        //Debug.Log("enabled again");
        netCollider.enabled = true;
        isHurt = false;
    }

    void LimitLength()
    {
        // Limits Length properly 
        Vector3 position = transform.position;
        float yPosition = Mathf.Clamp(transform.position.y, -7.0f, 2.55f);
        position.y = yPosition;

        transform.position = position;  
    }

    void DrawRope()
    {
        Rope.SetPosition(0, Ship.transform.position);
        Rope.SetPosition(1, transform.position);
    }
}

