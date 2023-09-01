using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;

    public GameObject coin;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 7.5f;
    public float coinDistanceOffset = 8;
    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }

        if (timer > spawnRate)
        {
            spawnPipe();
            spawnCoin();
            timer = 0;
        }

    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z), transform.rotation);
    }

    void spawnCoin()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(coin, new Vector3(transform.position.x + coinDistanceOffset, Random.Range(lowestPoint, highestPoint), transform.position.z), transform.rotation);
    }
}
