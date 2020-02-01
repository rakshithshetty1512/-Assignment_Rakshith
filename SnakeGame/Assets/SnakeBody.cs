using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
 void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag.Equals("wall")){
            UIManager.Instance.ActivateScreen<GameOverScreen>();
            EventHandler.TriggerGameOver();
        }
    }
}
