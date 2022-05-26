using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabManager : MonoBehaviour
{
    [Header("UI")]
    public Text messagetext;
    public InputField EmailInput;
    public InputField PasswordInput;

    public void RegisterButton(){
        if(PasswordInput.text.Length>6){
            messagetext.text="Password to short";
            return;
        }
        var request=new RegisterPlayFabUserRequest{Email=EmailInput.text,Password=PasswordInput.text,RequireBothUsernameAndEmail=false};
        PlayFabClientAPI.RegisterPlayFabUser(request,OnRegisterSuccess,OnError);
    }

    public void LoginButton(){
        var request=new LoginWithEmailAddressRequest{Email=EmailInput.text,Password=PasswordInput.text};
        PlayFabClientAPI.LoginWithEmailAddress(request,onloginSuccess,OnError);
    }

    void onloginSuccess(LoginResult result)
    {
      messagetext.text="Logged in";
      Debug.Log("Successful Login/Account create");
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result){
      messagetext.text="Registered and Logged in";
    }
    
    // Start is called before the first frame update
    void Start()
    {
        login();
    }

    void login(){
        var request=new LoginWithCustomIDRequest{CustomId=SystemInfo.deviceUniqueIdentifier,CreateAccount=true};
        PlayFabClientAPI.LoginWithCustomID(request,OnSuccess,OnError);
    }
    void OnSuccess(LoginResult result)
    {
       Debug.Log("Successful  login/account create");
    }
    void OnError(PlayFabError error){
        messagetext.text=error.ErrorMessage;
      Debug.Log("Error while logging in/creating account");
      Debug.Log(error.GenerateErrorReport());
    }

    //*************LEADERBOARD**********
    /*public void SendLeaderboard(int score){
        var request=new UpdatePlayerStatisticsRequest{
            Statistics=new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName="GameCompleted", Value=score
                    }
        }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request,OnLeaderBoardUpdate,OnError);
    }

    void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successful leaderboard sent");
    }*/
    //in game manager-->playfabmangaer.sendleaderboard()-->to recieve leaderboard data
    //leaderboard part isnot complete******
}
