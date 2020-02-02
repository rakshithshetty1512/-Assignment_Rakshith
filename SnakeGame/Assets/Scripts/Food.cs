using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Color color;
    private int score;
    private bool isTriggered;

    public void Init(int score, Color color)
    {
        //this.color = color;
        isTriggered = false;
        GetComponent<Renderer>().material.SetColor("_Color", color);
        this.score = score;

    }
    void OnTriggerEnter(Collider collider)
    {
        //add score
        if (collider.gameObject.tag.Equals("snake"))
        {
            if (isTriggered)
            {
                return;
            }
            else
            {
                isTriggered = true;
            }
            Destroy(this.gameObject);
            Debug.Log("color" + color + "score" + score);
            EventHandler.TriggerFoodConsumed();
            EventHandler.TriggerScore(score);
        }
        // if (collider.gameObject.tag.Equals("body"))
        // {
        //     if (isTriggered)
        //     {
        //         return;
        //     }
        //     else
        //     {
        //         isTriggered = true;
        //         Destroy(this.gameObject);
        //     }
        // }
    }
}
