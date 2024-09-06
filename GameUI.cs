using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public ScoreText player1ScoreText, player2ScoreText;
    public GameManager gameManager;
    public BallMovement ballMovement;
    public GameObject menuObject;
    public GameObject pauseObject;
    public GameObject gameOverObject;
    public GameObject playerThatWonText;

    public void UpdateScores(int player1Score, int player2Score)
    {
        player1ScoreText.SetScore(player1Score);
        player2ScoreText.SetScore(player2Score);
    }
    public void StartGameButton()
    {
        menuObject.SetActive(false);
        Time.timeScale = 1;
        gameManager.scorePlayer1 = 0;
        gameManager.scorePlayer2 = 0;
        UpdateScores(0, 0);
        ballMovement.StartBall(1);
    }
    public void PauseGame()
    {
        pauseObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGameButton()
    {
        pauseObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        gameOverObject.SetActive(false);
        Time.timeScale = 1;
        gameManager.scorePlayer1 = 0;
        gameManager.scorePlayer2 = 0;
        UpdateScores(0, 0);
    }
    public void PlayerThatWon(int playerThatWon)
    {
        playerThatWonText.GetComponent<TMPro.TextMeshProUGUI>().text = "Player " + playerThatWon + " Wins";
    }
}
