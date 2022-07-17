using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Joystick joystick;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(joystick.Horizontal ==0 & joystick.Vertical == 0)
        {
            animator.SetInteger("state", 0);
        }
        else
        {
            animator.SetInteger("state", 1);
        }
    }
}
