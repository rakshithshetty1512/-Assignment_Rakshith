using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : BaseUi
{
    // Start is called before the first frame update
    private Text scoreText;
    int score;
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = "SCORE: 0";
    }
    void OnEnable()
    {
        EventHandler.OnScoreUpdate += UpdateScore;     
    }
    void OnDisable()
    {
        EventHandler.OnScoreUpdate -= UpdateScore;
    }

    void UpdateScore(int score)
    {
        this.score += score;
        scoreText.text = "SCORE:" + this.score.ToString();
        if (PlayerPrefs.GetInt("score") < this.score)
        {
            PlayerPrefs.SetInt("score", this.score);
        }
    }
    public int GetScore()
    {
        scoreText.gameObject.SetActive(false);
        return score;
    }
}
