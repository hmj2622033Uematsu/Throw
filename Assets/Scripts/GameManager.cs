using JetBrains.Annotations;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform ball;
    [SerializeField] GameObject ballController;
    [SerializeField] GameObject distanceUI;
    [SerializeField] GameObject result;
    [SerializeField] GameObject muscleResylt;
    [SerializeField] GameObject totalMuscle;
    [SerializeField] GameObject playerController;
    [SerializeField] GameObject Title;
    [SerializeField] GameObject Player1;
    static float distance; // プレイヤーとボール距離（飛距離）
    string flyingDistance; // 飛距離（スコア）
    static int getMuscle = 0; // １プレイで獲得した筋力
    static int muscle = 0; // 総筋力
    //static int toTitle = 240;
    //static bool titleFlag = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void disUI() // 飛距離を表示
    {
        distanceUI.GetComponent<TextMeshProUGUI>().text = flyingDistance.ToString();
    }

    public void OVER() //
    {
        muscle += getMuscle;
        SceneManager.LoadScene("TitleScenes");// タイトルシーンに移動
        //titleFlag = true;
        //SceneManager.LoadScene("ResultScenes");
    }
    
    public void muscleUI()
    {
        totalMuscle.GetComponent<TextMeshProUGUI>().text = muscle.ToString();
    }
    public void play()
    {
        distance = Vector3.Distance(player.position, ball.position); // プレイヤーとボール間の距離を取得
        flyingDistance = distance.ToString(); // string型に変換
        getMuscle = Mathf.RoundToInt(distance); // int型に変換
    }

    void Update()
    {

        if (muscle >= 5)
        {
            playerController.GetComponent<PlayerController>().add1();
            //Title.GetComponent<TitleController>().one();
            GameObject player = Instantiate(Player1);
            Player1.transform.position = new Vector3(0, -4, 0);

        }
        if (muscle >= 200)
        {
            playerController.GetComponent<PlayerController>().add2();
            Debug.Log("o");
        }
        if (muscle >= 400)
        {
            playerController.GetComponent<PlayerController>().add3();
            
        }
        if (muscle >= 900)
        {
            playerController.GetComponent<PlayerController>().add4();
            
        }
        Debug.Log(distance);
        Debug.Log(getMuscle);
        result.GetComponent<TextMeshProUGUI>().text = distance.ToString();
        muscleResylt.GetComponent<TextMeshProUGUI>().text = getMuscle.ToString();
        //if (titleFlag == true) toTitle--;
        //if (toTitle < 0)
        //{
        //    titleFlag = false;
        //    distance = 0;
        //    toTitle = 240;
        //}
    }

}
