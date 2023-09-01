using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayingLogicScript : MonoBehaviour
{
    public int playerScore;
    public int playerCoins;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    public GameObject gameOverScreen;
    public GameObject soundManager;
    public AudioSource pointSound;
    public AudioSource buttonClick;
    public AudioSource coinSound;

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;

    [ContextMenu("Increase Score")]
    public void addScore(int score)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();
        currentScoreText.text = "Score: " + scoreText.text;

        if (playerScore % 5 == 0)
        {
            if (pointSound != null)
            {
                pointSound.Play();
            }
        }


    }

    public void addCoins(int value)
    {
        if (coinSound != null)
        {
            coinSound.Play();
        }
        playerCoins += value;
        coinText.text = playerCoins.ToString() + " coins";

    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void RestartWrapper()
    {
        Invoke("Restart", buttonClick.clip.length);
    }



    public void QuitWrapper()
    {
        Invoke("Quit", buttonClick.clip.length);
    }

    public void MainMenuWrapper()
    {
        Invoke("MainMenu", buttonClick.clip.length);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Quit()
    {
        Application.Quit();
    }

    private void MainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

}
