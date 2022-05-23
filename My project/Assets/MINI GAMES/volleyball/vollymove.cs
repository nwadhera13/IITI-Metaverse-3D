using UnityEngine;
using System.Collections;

public class vollymove : MonoBehaviour {

public Vector2 speed = new Vector2(10,10);
public Rigidbody2D rb;
private Vector2 movement = new Vector2(1,1);

// Use this for initialization
void Start () {
   rb=GetComponent<Rigidbody2D>();
}

// Update is called once per frame
void Update () {
    float inputX = Input.GetAxis ("Horizontal");
    float inputY = Input.GetAxis ("Vertical");

    movement = new Vector2(
        speed.x * inputX,
        speed.y * inputY);
        if (Input.GetKeyDown ("space")){
                         transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
                 } 

}
void FixedUpdate()
{
    // 5 - Move the game object
    rb.velocity = movement;
    //rigidbody2D.AddForce(movement);

}
}