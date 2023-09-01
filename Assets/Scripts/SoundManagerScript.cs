using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public AudioSource buttonClickSound;

    public void ButtonClick()
    {

        // Play the new sound effect
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }
    }
}
