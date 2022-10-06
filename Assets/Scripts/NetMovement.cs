using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetMovement : MonoBehaviour
{

    SpringJoint2D anchor;

    [Header("Length Anchor")]
    [SerializeField]
    float alterLength = 0.0001f;
    float timeToAlterLength = 0.02f;
    float MaxLength = 7.0f;

    void Awake()
    {
        anchor = GetComponent<SpringJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        NetUpAndDown();
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
        while (Input.GetMouseButton(0))
        {
            anchor.distance = Mathf.Clamp(anchor.distance + alterLength, 0.5f, MaxLength);
            yield return new WaitForSecondsRealtime(timeToAlterLength);
        }
    }

    IEnumerator MoveUp()
    {
        while (Input.GetMouseButton(1))
        {
            anchor.distance = Mathf.Clamp(anchor.distance - alterLength, 0.5f, MaxLength);
            yield return new WaitForSecondsRealtime(timeToAlterLength);
        }
    }
}

