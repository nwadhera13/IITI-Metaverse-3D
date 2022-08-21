using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionScript : MonoBehaviour
{
     public static int score = 0;
    public static int strike = 0;
    public int value = 10;
    void OnCollisionEnter(Collision collision)
    
    {
        if (collision.gameObject.tag == "player" ) {
        caught();
    }else{
        notCaught();
    }
    Destroy(gameObject);
    }

    void caught(){
        score += value;
        GameObject text = GameObject.FindGameObjectsWithTag("scoretext")[0];
        text.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
    }
    void notCaught(){
        strike++;
        GameObject text = GameObject.FindGameObjectsWithTag("striketext")[0];
        text.GetComponent<TMPro.TextMeshProUGUI>().text = strike.ToString();
        if(strike>2){
            gameOver();
        }
    }

    void gameOver(){
        Debug.Log("Game Over");
    }
}
