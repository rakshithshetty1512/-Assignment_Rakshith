using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    private bool isHead=true;
   public void Set(bool isHead){
        this.isHead=isHead;
    }
 void OnTriggerEnter(Collider collider){
     
        if(collider.gameObject.tag.Equals("wall")||(collider.gameObject.tag.Equals("Head")&&!isHead)){
            UIManager.Instance.ActivateScreen<GameOverScreen>();
            EventHandler.TriggerGameOver();
        }
    }
}
