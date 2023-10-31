using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetMoneyCollection : MonoBehaviour
{
    MoneyBar moneyScript;

    float moneyInNet = 0f;

    NetMovement net;

    [SerializeField]
    AudioClip bite;

    [SerializeField]
    GameObject LostFishes;

    Animator anim;

    Rigidbody2D rb2d;

    [SerializeField]
    AudioClip collectFish;

    [SerializeField]
    AudioClip collectinShip;

    private void Awake()
    {
        moneyScript = FindObjectOfType<MoneyBar>();
        net = FindObjectOfType<NetMovement>();
        anim =  GetComponent<Animator>();
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Triggered");

        if(collision.gameObject.tag == "Shark")
        {
            StartCoroutine(net.Hurt());
            AudioSource.PlayClipAtPoint(bite,Camera.main.transform.position);

            if(moneyInNet > 0)
            {
                GameObject lostfishes = Instantiate(LostFishes, transform.position, Quaternion.identity);
                lostfishes.GetComponent<ParticleSystem>().Play();
                Destroy(lostfishes, 3f);
                anim.SetFloat("Fishes", 0f);
            }
            moneyInNet = 0f;
        }

        else if (collision.gameObject.tag == "Pickable" && rb2d.velocity.y >= 0f)
        {

            Destroy(collision.gameObject);
            moneyInNet += collision.gameObject.GetComponent<SeaStuffMovement>().GetValue();
            anim.SetFloat("Fishes", moneyInNet);
            AudioSource.PlayClipAtPoint(collectFish,Camera.main.transform.position, 0.3f);
            //Add Sprite Logic

            //Debug.Log("Add Money");
        }

        else if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Happens");
            if (moneyInNet > Mathf.Epsilon) // if there is more money than 0
            {
                //Debug.Log("MoneyAdded");
                moneyScript.IncrementMoney(moneyInNet);
                moneyInNet = 0f;
                anim.SetFloat("Fishes", 0f);
                AudioSource.PlayClipAtPoint(collectinShip, Camera.main.transform.position, 0.3f);
            }
        }
    }
}
