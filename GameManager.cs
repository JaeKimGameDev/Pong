using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameUI gameUI;
    public GameObject gameOverObject;
    public ShakeByCollision screenShake;

    public int scorePlayer1, scorePlayer2;

    void Start()
    {
        scorePlayer1 = 0;
        scorePlayer2 = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameUI.PauseGame();
        }
    }
    public void ScoredPointOnPlayer(int id)
    {
        if (id == 1)
        {
            scorePlayer2++;
        }
        else if (id == 2)
        {
            scorePlayer1++;
        }

        gameUI.UpdateScores(scorePlayer1, scorePlayer2);

        if (scorePlayer1 > 4)
        {
            gameOverObject.SetActive(true);
            gameUI.PlayerThatWon(1);
            Time.timeScale = 0;
        }
        else if (scorePlayer2 > 4)
        {
            gameOverObject.SetActive(true);
            gameUI.PlayerThatWon(2);
            Time.timeScale = 0;
        }
    }
}
