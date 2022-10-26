using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject playFabManager;
    public GameObject scoreText;
    // public Script score;
 
    // public GameObject playFabManager;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
         if(GameObject.FindGameObjectWithTag("Player")== null){
            gameOverPanel.SetActive(true);
            // Time.timeScale =0;
            scoreText.SetActive(false);
            // playFabManager.SendLeaderboard((int)scoreText.maScore);
         }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
