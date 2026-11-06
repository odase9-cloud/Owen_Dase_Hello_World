
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController playerController;
    public List<astriod> asteriodList = new List<astriod>();

    public int score;
    public TMP_Text scoreText;
    public AudioSource audioSource;

    public GameObject winPanel;
    public GameObject losePanel;

    private bool gameEnded;

    public bool asteroidSpawningComplete = false;



    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        asteriodList = new List<astriod>();
        gameEnded = false;
    }

    private void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);

        if (losePanel != null)
            losePanel.SetActive(false);

        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (gameEnded)
            return;

        asteriodList.RemoveAll(asteroid => asteroid == null);

        if (scoreText != null)
            scoreText.text = " " + score;

        if (playerController != null &&
            playerController.pawn == null)
        {
            EndGame(false);
            return;
        }

        CheckForWin();
    }

    private void CheckForWin()
    {
        if (gameEnded || !asteroidSpawningComplete)
            return;

        asteriodList.RemoveAll(asteroid => asteroid == null);

        if (asteriodList.Count == 0)
        {
            EndGame(true);
        }
    }


    public void RegisterAsteroid(astriod asteroid)
    {
        if (asteroid == null)
            return;

        if (asteriodList == null)
            asteriodList = new List<astriod>();

        if (!asteriodList.Contains(asteroid))
        {
            asteriodList.Add(asteroid);
        }
    }

    public void AddToScore(int scoreToAdd)
    {
        if (audioSource != null)
            audioSource.Play();

        score += scoreToAdd;
    }

    public void EndGame(bool won)
    {
        if (gameEnded)
            return;

        gameEnded = true;

        if (winPanel != null)
            winPanel.SetActive(won);

        if (losePanel != null)
            losePanel.SetActive(!won);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void FinishAsteroidSpawning()
    {
        asteroidSpawningComplete = true;
    }
}
