using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBar : MonoBehaviour
{

    private Slider moneyBar;

    [Header("Money")]
    [SerializeField]
    private float maxMoneyValue;

    [SerializeField] TextMeshProUGUI scoreCounter;
    float currentMoney = 0f;

    private float noMoney = 0f;

    [SerializeField]
    private float DecreaseMoneyAmount = 2f;

    [Header("Time")]
    private float DecreaseMoneyTime = 0.5f;

    bool GameOver = false;

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
        currentMoney += Money;

        scoreCounter.text = currentMoney.ToString();
    }

    IEnumerator LoseMoney()
    {
        while(moneyBar.value > noMoney)
        {
            moneyBar.value -= DecreaseMoneyAmount;
            yield return new WaitForSeconds(DecreaseMoneyTime);
        }

        GameOver = true;
    }

    public bool GetGameOver()
    {
        return GameOver;
    }
}
