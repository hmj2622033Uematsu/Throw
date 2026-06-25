using System.Threading;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    float rightforse = 10; // 右へ飛ぶ力
    float upforse = 10; // 上へ飛ぶ力
    static float rightPower = 3;
    static float upPower = 2;
    float timer = 600;
    float waitTimer = 120;// 約２秒待つ
    bool waitFlag = false;
    bool moveFlag = false;
    float controlTimer = 120; // 止まっている信号を送るのを防ぐ
    bool throwFlag = false; // 投げたかどうか
    bool stoped = false; // ボールが止まっているかどうか
    [SerializeField] GameObject GameManager;
    [SerializeField] GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void power() // ボールの飛ぶ力
    {
        rightforse += rightPower;
        upforse += upPower;
    }

    public void addPower()
    {
        rightPower++;
        upPower++;
    }
    public void start() // ゲーム開始
    {
        timer -= 1;
        if (timer < 0 && throwFlag == false) // 10秒後且つ投げる前
        {
            if (Keyboard.current.enterKey.wasPressedThisFrame) // 投げる
            {
                throwFlag = true;
                moveFlag = true;
                rb.AddForce(transform.right * rightforse);
                rb.AddForce(Vector3.up * upforse);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (throwFlag == true) { controlTimer--; GameManager.GetComponent<GameManager>().disUI(); } // 飛距離を表示
        float speed = rb.linearVelocity.magnitude; // ボールの速度
        if (speed == 0 && throwFlag == true && controlTimer < 0) // 投げる前以外で速度が0
        {
            waitFlag = true; // 約二秒待つ
            Debug.Log("止まったよ");
            if(waitTimer < 0)GameManager.GetComponent<GameManager>().OVER(); // リザルトシーンへ
        }
        if (waitFlag == true) // 約二秒待つ
        {
            waitTimer--;
        }
        if(moveFlag == true) Player.GetComponent<PlayerController>().move(); // アニメーション開始

    }
}
