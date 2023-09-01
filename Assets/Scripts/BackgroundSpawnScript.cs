using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawnScript : MonoBehaviour
{
    public GameObject background;
    public float spawnRate = 5;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(background, new Vector3(0, 0, 0), transform.rotation);
        spawnBackground();
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
            spawnBackground();
            timer = 0;
        }

    }

    void spawnBackground()
    {
        Instantiate(background, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
    }
}
