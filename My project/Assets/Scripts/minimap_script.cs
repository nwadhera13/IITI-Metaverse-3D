using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap_script : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f,0f,0f);

    }
}
