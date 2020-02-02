using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpawnFood : MonoBehaviour
{
    public Food foodStub;
    public float planeOffset;
    public float foodYPosition;
    public List<FoodType> foodType;
    float randomnumber;
    //int ranadomZposition
    void Start()
    {
        Spawn();
    }
 void OnEnable()
    {
        EventHandler.OnFoodConsume += Spawn;
    }
    void OnDisable()
    {
        EventHandler.OnFoodConsume -= Spawn;
    }
    private void Spawn()
    {
        //System.Random random = new System.Random();
        int diection = UnityEngine.Random.Range(0,4);
        randomnumber = UnityEngine.Random.Range(0f, planeOffset);
        switch (diection)
        {
            case 0:
                SpawnObject(randomnumber, foodYPosition, randomnumber);
                break;
            case 1:
                SpawnObject(-randomnumber, foodYPosition, randomnumber);
                break;
            case 2:
                SpawnObject(-randomnumber, foodYPosition, -randomnumber);
                break;
            case 3:
                SpawnObject(-randomnumber, foodYPosition, -randomnumber);
                break;
        }
    }

    void SpawnObject(float xPosition, float yPosition, float zPosition)
    {
        Vector3 spawnPosition = new Vector3(xPosition, yPosition, zPosition);
        Food obj = Instantiate(foodStub, spawnPosition, Quaternion.identity);
        FoodType food = GetRandomFood();
        obj.Init(food.score, food.color);
    }

    private FoodType GetRandomFood()
    {
        System.Random random = new System.Random();
        //int index = random.Next(0, (foodType.Count - 1));
        int index=UnityEngine.Random.Range(0,(foodType.Count));
        return foodType[index];

    }
}
[Serializable]
public class FoodType
{
    public Color color=new Color();
    public int score;
}
