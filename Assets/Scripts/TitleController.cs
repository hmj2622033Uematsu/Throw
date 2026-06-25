using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("GameScenes"); // ÉQÅ[ÉÄÉVÅ[ÉìÇ÷
        }
        if (Keyboard.current.shiftKey.wasPressedThisFrame)
        {
            gameManager.GetComponent<GameManager>().moneyManager();
        }

    }
}
