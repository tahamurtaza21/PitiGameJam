using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBar : MonoBehaviour
{

    private Slider moneyBar;

    [Header("Money")]
    [SerializeField]
    private float maxMoneyValue;

    private float noMoney = 0f;

    [SerializeField]
    private float DecreaseMoneyAmount = 2f;

    [Header("Time")]
    private float DecreaseMoneyTime = 0.5f;

    // Start is called before the first frame update
    void Awake()
    {
        moneyBar = gameObject.GetComponent<Slider>();
        moneyBar.value = maxMoneyValue;
    }

    private void Start()
    {   
        StartCoroutine("LoseMoney");
    }

    public void IncrementMoney(float Money)
    {
        moneyBar.value += Money;
    }

    IEnumerator LoseMoney()
    {
        while(moneyBar.value > noMoney)
        {
            moneyBar.value -= DecreaseMoneyAmount;
            yield return new WaitForSeconds(DecreaseMoneyTime);
        }
    }
}
