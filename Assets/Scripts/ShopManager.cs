using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject BallController;
    [SerializeField] GameObject GameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.GetComponent<GameManager>().moneyManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
