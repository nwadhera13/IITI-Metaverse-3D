﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]float moveSpeed =4.0f;
    Vector3 forward,right;
    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        forward=Camera.main.transform.forward;
        forward.y=0;
        forward= Vector3.Normalize(forward);
        right=Quaternion.Euler(new Vector3(0,90,0))*forward;     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            move();
        }
    }
    void move()
    {
        Vector3 direction= new Vector3(joystick.Horizontal,0,joystick.Vertical);
        Vector3 rightMovement=right*moveSpeed*Time.deltaTime*joystick.Horizontal;
        Vector3 upMovement=forward*moveSpeed*Time.deltaTime*joystick.Vertical;
        Vector3 heading= Vector3.Normalize(rightMovement+upMovement);
        transform.forward+=heading;
        transform.position+=rightMovement;
        transform.position+=upMovement;
        
    }
}
