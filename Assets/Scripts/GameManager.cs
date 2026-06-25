using JetBrains.Annotations;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform ball;
    [SerializeField] GameObject ballController;
    [SerializeField] GameObject distanceUI;
    [SerializeField] GameObject result;
    [SerializeField] GameObject moneyResylt;
    [SerializeField] GameObject totalMoney;
    static float distance; // プレイヤーとボール距離（飛距離）
    string flyingDistance; // 飛距離（スコア）
    static int getMoney = 0; // １プレイで獲得した財貨
    static int money = 0; // 総財貨
    static int powerUpMoney = 25;
    static int toTitle = 240;
    static bool titleFlag = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void disUI() // 飛距離を表示
    {
        distanceUI.GetComponent<TextMeshProUGUI>().text = flyingDistance.ToString();
    }

    public void OVER() // リザルトシーンに移動
    {
        titleFlag = true;
        money += getMoney;
        SceneManager.LoadScene("ResultScenes");
    }
    
    public void moneyUI()
    {
        totalMoney.GetComponent<TextMeshProUGUI>().text = money.ToString();
    }

    public void play()
    {
        distance = Vector3.Distance(player.position, ball.position); // プレイヤーとボール間の距離を取得
        flyingDistance = distance.ToString(); // string型に変換
        getMoney = Mathf.RoundToInt(distance); // int型に変換
    }

    public void moneyManager()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            if(money > powerUpMoney)
            {
                money -= powerUpMoney;
                powerUpMoney += 50;
                ballController.GetComponent<BallController>().addPower();

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(distance);
        Debug.Log(getMoney);
        result.GetComponent<TextMeshProUGUI>().text = distance.ToString();
        moneyResylt.GetComponent<TextMeshProUGUI>().text = getMoney.ToString();
        if (titleFlag == true) toTitle--;
        if (toTitle < 0)
        {
            titleFlag = false;
            distance = 0;
            toTitle = 240;
            SceneManager.LoadScene("TitleScenes");// タイトルシーンに移動
        }
    }

}
