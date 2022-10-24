using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Update()
    {
        if(timer > timeBetweenSpawn)
        {
            Spawn();
            timer = 0.0f;
        }
        timer += Time.deltaTime;
    }

    // Update is called once per frame
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY,0),transform.rotation);
    }
}
