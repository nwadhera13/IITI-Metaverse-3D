using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameovr : MonoBehaviour
{
    public Text awon;
    public Text bwon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void display()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        if (score.ascore == 5)
        {
            awon.text = "PLAYER A HAS WON";
        }
        if (score.bscore == 5)
        {
            bwon.text = "PLAYER B HAS WON";
        }
    }
    public void restart()
    {
        SceneManager.LoadScene("volleyball");
    }
    public void end()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
