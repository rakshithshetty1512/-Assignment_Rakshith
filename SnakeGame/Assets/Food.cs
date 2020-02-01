using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Color color;
    private int score;


    public void Init(int score, Color color)
    {
        //this.color = color;
        GetComponent<Renderer>().material.SetColor("_Color",color);
        this.score = score;

    }
    void OnTriggerEnter(Collider collider)
    {
        //add score
        if (collider.gameObject.tag.Equals("snake"))
        {
            EventHandler.TriggerFoodConsumed();
            EventHandler.TriggerScore(score);
            Destroy(this.gameObject);
        }
    }
}
