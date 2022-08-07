using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayFabManager : MonoBehaviour
{
    [Header("UI")]
    public Text messagetext;
    static public string emaut;
    public InputField EmailInput;
    public InputField PasswordInput;

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
        emaut = EmailInput.text;
        Debug.Log(emaut);
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

    /*public void display()
    {
        PlayFabClientAPI.LoginWithPlayFab(new PlayFab.ClientModels.LoginWithPlayFabRequest
            {
            Username = "",
            Password = ""
        }, result =>
        {
            var displayName = result.InfoResultPayload.PlayerProfile.Email;
            Debug.Log(displayName);
        }, error =>
        {
            Debug.Log("No UserName");
        });
    }*/

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
    //test checking
}
