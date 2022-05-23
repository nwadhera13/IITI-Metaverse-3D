using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class vollymove : MonoBehaviour {

public Vector2 speed = new Vector2(10,10);
public Rigidbody2D rb;
private Vector2 movement = new Vector2(1,1);
public Joystick joystick;
// Use this for initialization
void Start () {
   rb=GetComponent<Rigidbody2D>();
}
// Update is called once per frame
void Update () {
    float inputX = joystick.Horizontal;
    float inputY = joystick.Vertical;
    movement = new Vector2(speed.x * inputX,rb.velocity.y);
    }
void FixedUpdate()
{
    rb.velocity = movement;
}
public void jump(){
        transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
}
}