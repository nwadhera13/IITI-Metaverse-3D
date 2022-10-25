using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
// import PlayFabManager;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text finalScoreText;
    private float score;
    private float maxScore;
    public GameObject playFabManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = ((int)score).ToString();
            finalScoreText.text = "your score is " + scoreText.text ;
            
        }
        // else{
        //     maxScore = score;
        //     // playFabManager.SendLeaderboard((int)maxScore);
            
        //     //  
        // }
    }
    
}
