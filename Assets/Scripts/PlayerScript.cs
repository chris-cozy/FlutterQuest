using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float additionalGravity = 1.0f; // Adjust as needed
    public float flapStrength;
    public PlayingLogicScript logic;
    public bool birdIsAlive = true;
    public float rotationSpeed = 10f;
    public float maxRotationAngle = 45f; // Maximum tilt angle
    public SpriteRenderer mySprite;
    public AudioSource wingFlapSound;
    public AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<PlayingLogicScript>();
        myRigidbody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.AddForce(Vector2.down * Physics2D.gravity.magnitude * (additionalGravity - 1));
        // Get the velocity vector of the player
        Vector2 velocity = myRigidbody.velocity;

        // Calculate the angle in degrees
        float targetAngle = Mathf.Clamp(
            Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg,
            -maxRotationAngle,
            maxRotationAngle
        );
        // Smoothly interpolate between current and target rotations
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
        mySprite.transform.rotation = Quaternion.Slerp(
            mySprite.transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            if (wingFlapSound != null)
            {
                wingFlapSound.Play();
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        if (birdIsAlive)
        {
            if (deathSound != null)
            {
                deathSound.Play();
            }
        }

        birdIsAlive = false;

    }
}
