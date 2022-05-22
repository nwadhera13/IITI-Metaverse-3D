﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing =5.0f;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset=transform.position-target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetCamPos=target.position+offset;
        transform.position=Vector3.Lerp(transform.position,targetCamPos,smoothing*Time.deltaTime);
    }
}
