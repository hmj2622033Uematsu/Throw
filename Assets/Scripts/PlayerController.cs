using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject GameManager;
    [SerializeField] Sprite swingSprites;
    [SerializeField] Sprite throwSprites;
    float timer = 600; // 10秒待つ
    float movetimer = 0; // アニメーションの間隔
    bool startFlag = false; // スタートするかしないか
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            startFlag = true;
        }
        if (startFlag == true)
        {
            ball.GetComponent<BallController>().start();
            GameManager.GetComponent<GameManager>().play();
            timer -= 1;
            if (timer > 0) // ゲーム開始
            {
                Debug.Log("スタート");
                if (Keyboard.current.spaceKey.wasPressedThisFrame)
                {
                    ball.GetComponent<BallController>().power();
                }
            }
            else // ゲーム終了
            {
                Debug.Log("終了");
            }
        }
    
    }
        // アニメーション
    public void move()
    {
        movetimer += 1;
        spriteRenderer.sprite = swingSprites;
        if (movetimer > 10) spriteRenderer.sprite = throwSprites;
    }

}

