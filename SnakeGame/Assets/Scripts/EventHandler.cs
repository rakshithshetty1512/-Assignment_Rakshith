using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler //: MonoBehaviour
{

    public delegate void UpdateScore(int score);
    public static event UpdateScore OnScoreUpdate;
    public static void TriggerScore(int score)
    {
        OnScoreUpdate?.Invoke(score);
    }

    public delegate void FoodConsumed();
    public static event FoodConsumed OnFoodConsume;
    public static void TriggerFoodConsumed()
    {
        OnFoodConsume?.Invoke();
    }

    public delegate void GameOver();
    public static event GameOver onGameOver;
    public static void TriggerGameOver()
    {
        onGameOver?.Invoke();
    }

}
