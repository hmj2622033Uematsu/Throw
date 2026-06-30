using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField] GameObject GameManager;
    //[SerializeField] GameObject Player1;
    //[SerializeField] GameObject Player2;
    //[SerializeField] GameObject Player3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.GetComponent<GameManager>().muscleUI();
    }

    //public void one()
    //{
    //    GameObject player = Instantiate(Player1);
    //    Player1.transform.position = new Vector3(0, -4, 0);
    //}
    // Update is called once per frame
    void Update()
    {
        //GameObject player2 = Instantiate(Player2);
        //GameObject player3 = Instantiate(Player3);
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("GameScenes"); // ÉQÅ[ÉÄÉVÅ[ÉìÇ÷
        }


    }
}
