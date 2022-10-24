using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private float directionY = 0;
    private Touch touch;
    private float ScreenWidth;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ScreenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.touchCount > 0){
        //         touch = Input.GetTouch(0);
        //         if(touch.phase == TouchPhase.Stationary)
        //         {
        //             rb.velocity = new Vector2(0,transform.position.y +touch.deltaPosition.y*playerSpeed);
        //         }
        // }
        



        // for (int i = 0; i < Input.touchCount; ++i)
        // {
        //     if (Input.GetTouch(i).phase == TouchPhase.Began)
        //     {
        //         float directionY=+1;            }
        // }
        // if(Input.GetTouch(0)){
               
        // }
        //  = Input.Gettouch("Vertical");
        
        int i=0;
        while(i<Input.touchCount){
            while(i<Input.touchCount){
                if(Input.GetTouch(i).position.x>ScreenWidth/2){
                    directionY = +1;
                    playerDirection = new Vector2(0,directionY).normalized;
                }
                if(Input.GetTouch(i).position.x<ScreenWidth/2){
                     directionY = -1;
                    playerDirection = new Vector2(0,directionY).normalized;
                }
                ++i;
            }
        }
    }

    // public void up(){
    //     directionY = +1;

    // }
    // public void down(){
    //     directionY = -1;
    // }
    void FixedUpdate(){
        rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }
    private void UpDown(float verticalInput){
        rb.AddForce(new Vector2(0,verticalInput*playerSpeed*Time.deltaTime));
    }
}
