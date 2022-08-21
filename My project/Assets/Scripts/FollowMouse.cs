using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    int score;
    private Vector3 position;
    private float width;
    private float height;
    public GameObject gameManager;
    bool gameOver;
    public SpriteRenderer spriteRenderer;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
    }
    void Update()
    {   
        score = gameManager.GetComponent<gameScript>().score;
        if(score>500){
            ChangeSprite(1);
        }else if(score>2000){
            ChangeSprite(2);
        }else if(score>5000){
            ChangeSprite(3);
        }
        gameOver = gameManager.GetComponent<gameScript>().IsGameOver;
        if(Input.touchCount>0 && !gameOver){
        Touch touch = Input.GetTouch(0);
        
        Vector2 pos = touch.position;
        pos.x = (pos.x-width)/width;
        position = new Vector3(pos.x, 0f, 0f);
        
        if( transform.position.x< 105){
            transform.position += position;
        }else{
            transform.position = new Vector3(104.9f,-31.9f,90f);
        }
        if(-100 < transform.position.x){
            transform.position += position;
        }else{
            transform.position = new Vector3(-99.9f,-31.9f,90f);
        }
    }
    }

    void ChangeSprite(int x)
    {
        if(x==1){
            spriteRenderer.sprite = Sprite1;
        }else if(x==2){
            spriteRenderer.sprite = Sprite2;
        }else if(x==3){
            spriteRenderer.sprite = Sprite3;
        }
        
    }
}