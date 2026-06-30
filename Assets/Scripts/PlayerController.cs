using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject GameManager;
    [SerializeField] GameObject spBubble;
    [SerializeField] Sprite swingSprites;
    [SerializeField] Sprite throwSprites;
    [SerializeField] AudioClip throwSE;
    [SerializeField] AudioClip startSE;
    AudioSource aud;
    float timer = 600; // 10秒待つ
    float movetimer = 0; // アニメーションの間隔
    bool startFlag = false; // スタートするかしないか
    static bool addFlag1 = false;
    static bool addFlag2 = false;
    static bool addFlag3 = false;
    static bool addFlag4 = false;
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            startFlag = true;
            AudioSource.PlayClipAtPoint(startSE, transform.position);
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
                    AudioSource.PlayClipAtPoint(throwSE, transform.position);
                    //if (addPower == true)
                    //{
                    if (addFlag1 == true)ball.GetComponent<BallController>().addPower1();
                    if (addFlag2 == true)ball.GetComponent<BallController>().addPower2();
                    if (addFlag3 == true)ball.GetComponent<BallController>().addPower3();
                    //}
                }
            }
            else // ゲーム終了
            {
                Debug.Log("終了");
                GameObject sp = Instantiate(spBubble);
                sp.transform.position = new Vector3(1, -3, 0);
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
    public void add1()
    {
        addFlag1 = true;
        
    }
    public void add2()
    {
        addFlag2 = true;
        Debug.Log("b");
    }
    public void add3()
    {
        addFlag3 = true;
        
    }
    public void add4()
    {
        addFlag4 = true;
        
    }

}

