using System.Threading;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    float rightforse = 10; // 右へ飛ぶ力
    float upforse = 10; // 上へ飛ぶ力
    float timer = 600;
    float waitTimer = 1200; // 約２秒待つ
    float controlTimer = 60; // 止まっている信号を送るのを防ぐ
    bool throwFlag = false; // 投げたかどうか
    bool stoped = false; // ボールが止まっているかどうか
    [SerializeField] GameObject GameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void power() // ボールの飛ぶ力
    {
        rightforse += 3;
        upforse += 3;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= 1;
        if (timer < 0 && throwFlag == false)
        {
            if (Keyboard.current.enterKey.wasPressedThisFrame)
            {
                throwFlag = true;
                rb.AddForce(transform.right * rightforse);
                rb.AddForce(Vector3.up * upforse);
            }
        }
        if (throwFlag == true) { controlTimer--; GameManager.GetComponent<GameManager>().disUI(); }
        float speed = rb.linearVelocity.magnitude; // ボールの速度
        if (speed == 0 && throwFlag == true && controlTimer < 0) // 最初以外で速度が０、投げた後
        {
            Debug.Log("止まったよ");
            GameManager.GetComponent<GameManager>().OVER();
        }
    }
}
