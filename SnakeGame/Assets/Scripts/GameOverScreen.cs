using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : BaseUi
{
public Text currentScore;
void OnEnable(){
   ScoreHandler score= UIManager.Instance.GetScreen<ScoreHandler>();
    currentScore.text="Score: "+score.GetScore().ToString();
}
public void OnButtonPressed(){
    string buttonName=EventSystem.current.currentSelectedGameObject.name;
    ButtonPreassed(buttonName);
}
void ButtonPreassed(string name){
    switch(name){
        case "Retry":
        SceneManager.LoadScene("Loading");
        break;
        case "Quit":
        Application.Quit();
        break;

    }
}
        
}
