using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    

    public int value = 10;
    GameObject gameManager;
    void Awake(){
        gameManager =  GameObject.FindGameObjectsWithTag("gameManager")[0];
    }
    void OnCollisionEnter2D(Collision2D collision){
    
    if (collision.gameObject.tag == "player" ) {
        caught();
        Destroy(gameObject);
    }else if (collision.gameObject.tag == "Finish" ) {
        Destroy(gameObject);
    }
    
    
    }
    void caught(){
        gameManager.GetComponent<gameScript>().incScore(value);
    }


}
