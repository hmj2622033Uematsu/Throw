using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ball;
    float timer = 600;
    float startTimer = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame) {startTimer -= 1;}
        if (startTimer < 0)
        {
            timer -= 1;
            if (timer > 0)
            {
                Debug.Log("スタート");
                if (Keyboard.current.spaceKey.wasPressedThisFrame)
                {
                    ball.GetComponent<BallController>().power();
                }
            }
            else
            {
                Debug.Log("終了");
            }
        }
        
    }
}
