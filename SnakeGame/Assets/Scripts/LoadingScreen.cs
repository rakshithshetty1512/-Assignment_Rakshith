using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Text score;
    void OnEnable(){
        if(!PlayerPrefs.HasKey("score")){
            PlayerPrefs.SetInt("score",0);
        }
        score.text="Top Score:"+PlayerPrefs.GetInt("score").ToString();
    }
  public void OnButtonPressed(){
      string btnName=EventSystem.current.currentSelectedGameObject.name;
      OnButtonPressed(btnName);
  }

    private void OnButtonPressed(string btnName)
    {
        switch(btnName){
            case "Play":
            SceneManager.LoadScene("Game");
            break;
        }
    }
}
