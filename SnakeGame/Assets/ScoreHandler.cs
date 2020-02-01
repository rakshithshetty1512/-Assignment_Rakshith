using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private Text scoreText;
    void Start()
    {
        scoreText=GetComponent<Text>();
    }
    void OnEnable(){
        EventHandler.OnScoreUpdate+=UpdateScore;
    }
    void OnDisable(){
          EventHandler.OnScoreUpdate-=UpdateScore;
    }

    void UpdateScore(int score){
        scoreText.text="SCORE:"+score.ToString();
    }
}
