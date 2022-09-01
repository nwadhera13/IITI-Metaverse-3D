using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class gameScript : MonoBehaviour
{
    System.Random rnd = new System.Random();
    bool Spawning = false;
    bool counting = false;
    public float timeGap = 15f;
    public GameObject spawner;
    [SerializeField] TMP_Text timer;
    [SerializeField] TMP_Text scoretext;
    [SerializeField] TMP_Text finalScore;
    public int currentseconds = 0;
    public int currentminutes = 2;
    string time;
    public bool IsGameOver =false;
    public static bool IsStarted =false;
    public static bool GameIsStarting = true;
    public int score =0;
    PlayFabManager playfabmanager;
    AudioManager audiomanager;
    private Animator anim;
    public GameObject player;
    public GameObject intro;
    public GameObject complete;
    void Start(){
        anim = player.GetComponent<Animator>();
        audiomanager = FindObjectOfType<AudioManager>();
        audiomanager.PlaySound("background");
        playfabmanager= GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<PlayFabManager>();
        playfabmanager.login();
        time = ((currentminutes<10) ? ("0"+ currentminutes.ToString()): (currentminutes.ToString())) +":" + ((currentseconds<10) ? ("0"+ currentseconds.ToString()): (currentseconds.ToString()));
        timer.text = time;

        Time.timeScale = 0.01f;
        StartCoroutine(StartingAnim());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q")){
            gameOver();
        }
        
        
        if(!IsGameOver){
        if(Spawning == false){
            StartCoroutine(CreateNew());
        }
        if(!counting){
            StartCoroutine(Counter());
        }
        }else{
            if(IsStarted){
            gameOver();
            }
        
        }
    }
    public void gameOver(){
        Debug.Log("Game Over");
        playfabmanager.SendLeaderboard(score);
        playfabmanager.GetLeaderboard();
        IsStarted =false;
        IsGameOver= true;
        audiomanager.PlaySound("pop");
        finalScore.text = score.ToString();
        
        complete.SetActive(true);
        Time.timeScale = 0f;
    }
    IEnumerator StartingAnim(){
        if(GameIsStarting){
            GameIsStarting = false;
        }
        yield return new WaitForSeconds(0.05f);
        Time.timeScale = 1f;
        IsStarted = true;
        intro.SetActive(false);
        player.SetActive(true);
    }
    IEnumerator CreateNew(){
        Spawning = true;
        yield return new WaitForSeconds(timeGap);
        if(!IsGameOver){
        Instantiate(spawner, SpawnLocation(), Quaternion.identity);

        if(timeGap > 2f){
        timeGap -= 0.5f;
        }
        }
        Spawning= false;
    }
    Vector3 SpawnLocation(){

        int x = rnd.Next(-100,100);
        return new Vector3(x,69f,90.90752f);

    }

    IEnumerator Counter(){
        counting = true;
        
        yield return new WaitForSeconds(1);
        currentseconds -= 1;
        if(currentseconds == -1){
            currentseconds = 59;
            currentminutes -= 1;
        }
        if(currentminutes == -1){
            timer.text = "00:00";
            counting = true;
            gameOver();

        }else{
        time = ((currentminutes<10) ? ("0"+ currentminutes.ToString()): (currentminutes.ToString())) +":" + ((currentseconds<10) ? ("0"+ currentseconds.ToString()): (currentseconds.ToString()));
        timer.text = time;
        counting = false;
        }
    }
    public void incScore(int value){
        score+=value;
        scoretext.text = score.ToString();
        audiomanager.PlaySound("pop");
        StartCoroutine(CollectAnim());
    }
    IEnumerator CollectAnim(){
        anim.SetBool("collect",true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("collect",false);
    }
}
