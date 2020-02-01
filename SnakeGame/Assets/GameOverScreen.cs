using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOverScreen : BaseUi
{

public void OnButtonPressed(){
    string buttonName=EventSystem.current.currentSelectedGameObject.name;
    ButtonPreassed(buttonName);
}
void ButtonPreassed(string name){
    switch(name){
        case "Retry":
        SceneManager.LoadScene("Game");
        break;
        case "Quit":
        Application.Quit();
        break;

    }
}
        
}
