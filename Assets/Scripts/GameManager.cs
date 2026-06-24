using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform ball;
    [SerializeField] GameObject distanceUI;
    [SerializeField] GameObject result;
    [SerializeField] GameObject moneyText;
    float distance;
    static string flyingDistance;
    float timer = 600;
    float waitTimer = 1200;
    static int money;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void disUI()
    {
        distanceUI.GetComponent<TextMeshProUGUI>().text = flyingDistance.ToString();
    }

    public void OVER()
    {       
        SceneManager.LoadScene("ResultScenes");
    }

    // Update is called once per frame
    void Update()
    {
        timer--;
        distance = Vector3.Distance(player.position, ball.position);
        flyingDistance = distance.ToString();
        money = Mathf.RoundToInt(distance);
        if(timer < 0)Debug.Log(flyingDistance);
        if(timer < 0)Debug.Log(money);
    }

}
