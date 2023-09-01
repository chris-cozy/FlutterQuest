using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleTrigger : MonoBehaviour
{
    public PlayingLogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        // When the pipe spawns, it looks for the logic manager, and accesses the script to add to the component.
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<PlayingLogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.addScore(1);
        }

    }
}
