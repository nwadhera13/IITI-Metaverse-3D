using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseScript : MonoBehaviour
{

    public bool isGrounded = true;

    

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            isGrounded = true;
        }            
         
    }


    void OnCollisionExit2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            isGrounded = false;
        }
        
    }

}
