using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public SnakeBody snake;
    public List<SnakeBody> snakeBody;
    public float snakeSpeed;
    public float minDistBtwBd;
    public float rotatingSpeed;
    public Vector3 offset = new Vector3(0, 0, 1f);
    private SnakeBody currentPart;
    private SnakeBody nextPart;
    private float distBtwAdjPart;
    void Start()
    {
        for (int i = 0; i <= 1; i++)
        {
            SpawnNewPart();
        }
    }
    void OnEnable()
    {
        EventHandler.OnFoodConsume += SpawnAfterConsumption;
        EventHandler.onGameOver += Gameovar;
    }

    void OnDisable()
    {
        EventHandler.OnFoodConsume -= SpawnAfterConsumption;
        EventHandler.onGameOver -= Gameovar;
    }
    void Move()
    {
        snakeBody[0].transform.Translate(snakeBody[0].transform.forward * Time.deltaTime * snakeSpeed, Space.World);
        if (Input.GetAxis("Horizontal") != 0)
        {
            Vector3 rotate = Vector3.up * Time.deltaTime * rotatingSpeed * Input.GetAxis("Horizontal");
            snakeBody[0].transform.Rotate(rotate);
        }
        for (int i = 1; i < snakeBody.Count; i++)
        {
            currentPart = snakeBody[i - 1];
            nextPart = snakeBody[i];
            distBtwAdjPart = Vector3.Distance(currentPart.transform.position, nextPart.transform.position);
            //float temp = Time.deltaTime * distBtwAdjPart / minDistBtwBd * snakeSpeed;
            float temp =(distBtwAdjPart-minDistBtwBd)/distBtwAdjPart;// / minDistBtwBd;
            Vector3 newPOsition = currentPart.transform.position;
            newPOsition.y = snakeBody[0].transform.position.y;
            // if (temp > 0.5f)
            // {
            //    //temp = 0.5f;
            // }
          
        Debug.Log(Vector3.Slerp(nextPart.transform.position, newPOsition, temp)+","+nextPart.transform.position);
            nextPart.transform.position = Vector3.Slerp(nextPart.transform.position, newPOsition, temp);
            Debug.Log(nextPart.transform.position);
            nextPart.transform.rotation = Quaternion.Slerp(nextPart.transform.rotation, currentPart.transform.rotation,temp);
        }

    }
    void SpawnNewPart()
    {

        Debug.Log("called spawn");
        SnakeBody obj = Instantiate(snake);
        obj.transform.SetParent(this.transform);
        obj.transform.position = snakeBody[snakeBody.Count - 1].transform.position;
        obj.transform.rotation = snakeBody[snakeBody.Count - 1].transform.rotation;
        Vector3 position = obj.transform.position - offset;
        obj.transform.position = position;
        obj.Set(false);
        snakeBody.Add(obj);

    }

    void SpawnAfterConsumption()
    {
        SnakeBody obj = Instantiate(snake, snakeBody[snakeBody.Count - 1].transform.position, snakeBody[snakeBody.Count - 1].transform.rotation);
        obj.transform.SetParent(this.transform);
        obj.Set(false);
        snakeBody.Add(obj);
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Gameovar()
    {
        snakeSpeed = 0f;
    }

}
