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
    int maxLife = 3;

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
<<<<<<< HEAD
=======

        isGameover = true;

>>>>>>> parent of 1ec7b2a (FIxed : ê²Œìž„ ì—”ë”© ì¡°ê±´ ì¶”ê°€)
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
            timetext.text = "Time: " + (int)survivetime;//½Ã°£ °»½Å
            toy.text = "ÀÎÇü °¹¼ö: 12/ " + inventory.ToyCount;
            Life.text = "»ý¸í·Â: " +(maxLife - controller.hitCount);
        }
        
    }
}
