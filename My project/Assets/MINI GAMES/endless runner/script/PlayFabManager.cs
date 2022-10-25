using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayFabLogin : MonoBehaviour
{
    public Text ScoreText;
    
    private float score;
    private float maxScore;
       
    // Start is called before the first frame update
    private void Start()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = "GettingStartedGuide",
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess , OnLoginFailure);
    }

    // Update is called once per frame
    private void OnLoginSuccess(LoginResult result){
        Debug.Log("Login Success");

    }
    private void OnLoginFailure(PlayFabError error){
        Debug.Log(error.GenerateErrorReport());
        
    }
    public void SendLeaderboard(int score){
        var request = new UpdatePlayerStatisticsRequest{
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName = "PlayerScore",
                    Value = score
                }

            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request , OnLeaderboardUpdate,OnLoginFailure);
    }
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result){
        Debug.Log("Successfull leaderboard sent");
    }

    void update(){
         if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime;
            
            
        }
        else{
            maxScore = score;
            SendLeaderboard((int)maxScore);
            // playFabManager.SendLeaderboard((int)maxScore);
            
            //  
        }
        if(GameObject.FindGameObjectWithTag("Player") == null){

    //  PlayFabManager playfabMananger = GameObject.Find("PlayFabManager").GetComponent<PlayFabManager>();
              
        }
    }
    
   
}
