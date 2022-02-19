using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score elements")]
    public Text scoreText;
    public int score;
    public int highScore;
    public Text highscoreText;
    [Header("Game over stuff")]
    public GameObject endgamePanel;
    public Text endgamePanelScoreText;
    private void Awake()
    {
        endgamePanel.SetActive(false);
        highScore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = highScore.ToString();
    }
    public void IncreaseScore(int points)
    {
        score+=points;
        scoreText.text = score.ToString();
        if(score > highScore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScore=score;
            highscoreText.text = highScore.ToString();
            
        }
    }
    public void OnBombHit()
    {
        endgamePanelScoreText.text = score.ToString();
        endgamePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        score = 0;
        scoreText.text = "0";
        endgamePanelScoreText.text="0";
        endgamePanel.SetActive(false );
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }
        Time.timeScale=1;
    }

}
