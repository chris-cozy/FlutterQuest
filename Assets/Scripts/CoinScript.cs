using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int coinValue = 1; // The value of this coin when picked up
    public PlayingLogicScript logic;
    public float moveSpeed = 1;
    public float deadZone = -45;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (logic != null)
            {
                logic.addCoins(coinValue);
            }



            // Delete the coin
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<PlayingLogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("Coin Deleted");
            Destroy(gameObject);
        }

    }
}
