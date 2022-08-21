using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class spawnitems : MonoBehaviour
{   
    System.Random rnd = new System.Random();
    public GameObject item;
    public float spawntime= 3f;
    public float spawnerLife = 12f;
    bool spawning = false;
    public GameObject[] items;
    void Awake(){
        StartCoroutine(selfDestruct());
    }
    void Update()
    {
        if(!spawning){
            StartCoroutine(spawn());
        }
    }
    IEnumerator spawn(){
        spawning = true;
        yield return new WaitForSeconds(spawntime);
        int y = rnd.Next(0,100);
        int r = 0;
        if(y<10){
            r=0;
        }else if(9<y && y <30){
            r=1;
        }else if(29<y&& y<60){
            r=2;
        }else if(59<y && y< 65){
            r=4;
        }else{
            r=3;
        }
        GameObject item = items[r];
        Instantiate(item, transform.position,SpawnRotation());

        if(spawntime > 5f){
        spawntime -= 0.5f;
        }
        spawning= false;
    }
        Quaternion SpawnRotation(){

        int z = rnd.Next(-45,45);
        Vector3 rotationVector = new Vector3(0, 0, z);
        return Quaternion.Euler(rotationVector);

    }
    IEnumerator selfDestruct(){
        yield return new WaitForSeconds(spawnerLife);
        Destroy(gameObject);
    }

}
