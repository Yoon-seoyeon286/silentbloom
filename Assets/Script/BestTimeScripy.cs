using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BestTimeScripy : MonoBehaviour
{

    public Text BestTime;
    
    void Start()
    {
        float bestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue);

        if (bestTime < float.MaxValue)
        {
            BestTime.text = "BestTime: " + ((int)bestTime);
        }
    }


    public void ReGame()
    {
        SceneManager.LoadScene("SampleScene");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
