using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float timeLimit = 60f; // Timer limit in seconds
    private float currentTime;

    public int totalMugs = 3; // Total mugs to collect
    private int mugsCollected = 0;

    public TextMeshProUGUI timerText;      // UI for the timer
    public TextMeshProUGUI mugsLeftText;   // UI for mugs left

    public GameObject winScreenCanvas;     // Canvas for win screen
    public GameObject loseScreenCanvas;    // Canvas for lose screen

    private bool gameEnded = false;        // To prevent multiple triggers

    void Start()
    {
        currentTime = timeLimit;
        UpdateMugsLeftUI();
        winScreenCanvas.SetActive(false);
        loseScreenCanvas.SetActive(false);
    }

    void Update()
    {
        if (gameEnded) return; // Stop the timer if the game has ended

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            ShowLoseScreen(); // Timer ran out
        }
    }

    public void MugCollected()
    {
        if (gameEnded) return;

        mugsCollected++;
        UpdateMugsLeftUI();

        if (mugsCollected >= totalMugs)
        {
            ShowWinScreen();
        }
    }

    void ShowWinScreen()
    {
        if (gameEnded) return;

        Debug.Log("You Win!");
        gameEnded = true; // Mark the game as ended
        Time.timeScale = 0f; // Pause the game
        winScreenCanvas.SetActive(true); // Show the Win Screen
    }

    void ShowLoseScreen()
    {
        if (gameEnded) return;

        Debug.Log("You Lose!");
        gameEnded = true; // Mark the game as ended
        Time.timeScale = 0f; // Pause the game
        loseScreenCanvas.SetActive(true); // Show the Lose Screen
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void UpdateMugsLeftUI()
    {
        int mugsLeft = totalMugs - mugsCollected;
        mugsLeftText.text = "Mugs Left: " + mugsLeft;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f; // Reset the game speed
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
