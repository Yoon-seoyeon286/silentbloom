using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerInventory inventory;
    PlayerController controller;
    public Text timetext;
    float survivetime;
    bool isGameover;
    int maxLife = 5;

    public Text toy;
    public Text Life;
    public Text BestTime;
  
    
    void Start()
    {
        inventory = FindFirstObjectByType<PlayerInventory>();
        controller = FindFirstObjectByType<PlayerController>();
        
        survivetime = 0;
        isGameover = false;
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("StartGame");
    }


    public void ClearGame()
    {
        float bestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue);

        if (survivetime < bestTime)
        {
            bestTime = survivetime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            PlayerPrefs.Save();
        }

        SceneManager.LoadScene("Clear");
    }
    
    
    void Update()
    {
        if (!isGameover)
        {
            survivetime += Time.deltaTime;
            timetext.text = "Time: " + (int)survivetime;//시간 갱신
            toy.text = "인형 갯수: 12/ " + inventory.ToyCount;
            Life.text = "생명력: " +(maxLife - controller.hitCount);
        }

        if (inventory.ToyCount >= 12 && inventory.KeyCount >= 6)
        {
            ClearGame();
        }
        
    }
}
