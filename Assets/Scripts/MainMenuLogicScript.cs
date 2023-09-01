using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogicScript : MonoBehaviour
{
    public AudioSource buttonClick;
    public void PlayWrapper()
    {
        Invoke("Play", buttonClick.clip.length);

    }

    public void QuitWrapper()
    {
        Invoke("Quit", buttonClick.clip.length);
    }

    private void Play()
    {
        SceneManager.LoadSceneAsync("Playing");
    }

    private void Quit()
    {
        Application.Quit();
    }
}
