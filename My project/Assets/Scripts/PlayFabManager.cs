using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayFabManager : MonoBehaviour
{
    [Header("UI")]
    public Text messagetext;
    public InputField EmailInput;
    public InputField PasswordInput;
    
    public TMP_Text[] playerNames;
    public TMP_Text[] playerScores;
    
    public void RegisterButton(){
        if(PasswordInput.text.Length<6){
            messagetext.text="Password too short";
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
      SceneManager.LoadScene("SampleScene");
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result){
      messagetext.text="Registered and Logged in";
    }
    public void ResetPasswordButton(){
        var request=new SendAccountRecoveryEmailRequest{Email=EmailInput.text,TitleId="5E6AA"};
        PlayFabClientAPI.SendAccountRecoveryEmail(request ,OnPasswordReset,OnError);
    }
    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messagetext.text="Password reset mail sent";
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //login();
    }

    public void login(){
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
    public void SendLeaderboard(int score){
        var request=new UpdatePlayerStatisticsRequest{
            Statistics=new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName="FrescoLeaderboard", Value=score
                    }
        }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request,OnLeaderBoardUpdate,OnError);
    }

    void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successful leaderboard sent");
    }
    public void GetLeaderboard(){
        var request = new GetLeaderboardRequest{
            StatisticName = "FrescoLeaderboard",
            StartPosition = 0,
            MaxResultsCount = 5
        };
        PlayFabClientAPI.GetLeaderboard(request,OnLeaderBoardGet,OnError);

    }
    void OnLeaderBoardGet(GetLeaderboardResult result){
        int i = 0;
        foreach (var item in result.Leaderboard){
            Debug.Log(item.Position + " " +  item.PlayFabId + " " + item.StatValue);
            playerNames[i].text = item.PlayFabId;
            playerScores[i].text = item.StatValue.ToString();
            i++;
        }
    }
}
