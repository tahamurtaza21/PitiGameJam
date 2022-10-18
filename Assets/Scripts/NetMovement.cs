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
    float MaxLength = 7.0f;
    float MinLength = 0.5f;

    bool isHurt = false;

    void Awake()
    {
        Rope = GetComponentInChildren<LineRenderer>();
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
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("True");
            StartCoroutine("MoveDown");
        }

        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine("MoveUp");
        }
    }

    IEnumerator MoveDown()
    {
        while (Input.GetMouseButton(0) && isHurt == false)
        {
            anchor.distance = Mathf.Clamp(anchor.distance + alterLength, MinLength, MaxLength);
            netCollider.enabled = false;
            yield return new WaitForSecondsRealtime(timeToAlterLength);
        }
    }

    IEnumerator MoveUp()
    {
        while (Input.GetMouseButton(1) && isHurt == false)
        {
            anchor.distance = Mathf.Clamp(anchor.distance - alterLength, MinLength, MaxLength);
            netCollider.enabled = true;
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
            anchor.distance -= alterLength * 5;
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
        float yPosition = Mathf.Clamp(transform.position.y, -7.0f , Ship.transform.position.y - 0.5f);
        position.y = yPosition;

        transform.position = position;
    }

    void DrawRope()
    {
        Rope.SetPosition(0, transform.position);
        Rope.SetPosition(1, Ship.transform.position);
        
    }
}

