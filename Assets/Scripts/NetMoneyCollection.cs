using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetMoneyCollection : MonoBehaviour
{
    MoneyBar moneyScript;

    float moneyInNet = 0f;

    private void Awake()
    {
        moneyScript = FindObjectOfType<MoneyBar>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered");

        if (collision.gameObject.tag == "Pickable")
        {
            Destroy(collision.gameObject);
            moneyInNet += 10f;
            //Add Sprite Logic

            Debug.Log("Add Money");
        }

        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Happens");
            if (moneyInNet > Mathf.Epsilon) // if there is more money than 0
            {
                Debug.Log("MoneyAdded");
                moneyScript.IncrementMoney(moneyInNet);
            }
        }
    }
}
