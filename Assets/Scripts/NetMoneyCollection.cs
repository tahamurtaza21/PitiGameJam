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

    private void Awake()
    {
        moneyScript = FindObjectOfType<MoneyBar>();
        net = FindObjectOfType<NetMovement>();
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
            }

            
            moneyInNet = 0f;
        }

        if (collision.gameObject.tag == "Pickable")
        {
            Destroy(collision.gameObject);
            moneyInNet += 10f;
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
            }
        }
    }
}
