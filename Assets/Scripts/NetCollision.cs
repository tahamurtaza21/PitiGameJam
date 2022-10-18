using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetCollision : MonoBehaviour
{

    [SerializeField]
    AudioClip bounceClip;

    [SerializeField]
    AudioClip oceanFloor;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Left" || collision.gameObject.name == "Right")
        {
            AudioSource.PlayClipAtPoint(bounceClip, Camera.main.transform.position);
        }
        if (collision.gameObject.name == "Ocean Floor")
        {
            AudioSource.PlayClipAtPoint(oceanFloor, Camera.main.transform.position);
        }    
    }
}
