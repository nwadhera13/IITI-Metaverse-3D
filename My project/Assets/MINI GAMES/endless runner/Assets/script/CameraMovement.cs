using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        // if(GameObject.FindGameObjectWithTag("Player")== null){
        //     transform.position = new Vector3(0,0,0);
            
        //  }else{
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0 , 0);
        // }
    }
}
