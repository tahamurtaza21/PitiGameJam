using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

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

    [SerializeField] TextMeshProUGUI FinalScore;

    [SerializeField]
    GameObject gameCanvas;
    [SerializeField]
    GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Awake()
    {
        moneyBar = gameObject.GetComponent<Slider>();
        moneyBar.value = maxMoneyValue;
        gameCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
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

        GameOver();
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        FinalScore.text = (currentMoney.ToString());

    }

    public void GameRestart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
}
