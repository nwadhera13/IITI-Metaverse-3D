using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector3 lastvelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastvelocity=rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
      var speed=lastvelocity.magnitude;
      var direction=Vector3.Reflect(lastvelocity.normalized,coll.contacts[0].normal);
      rb.velocity=direction*Mathf.Max(speed,0f);
    }
}
