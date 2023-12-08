using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject ObstacleObject;

    public float SpawnTimer;
    public float EscalationTimer;
    public float WaveTimer;

    public float DifficultyScale = .2f; 
    public float SpeedModifier = 2f; //how much the speed increases over the course of a 'wave'
    public float BaseSpeed = 10f; //the default obstacle speed
    float CurrentSpeed; //speed of an obstacle when it spawns in

    public float SpawnRate = 1f;
    float InitialRate;

    public float WaveTime = 30f; //the amount of time between waves. 'ObstacleDensity' is increased after each wave
    public float EscalationAmount = .5f; //The amount that the spawn rate increases 

    [Range(1, 8)] //Attribute limiting the range of a numerical value
    public int ObstacleDensity; //The amount of obstacles spawned at once


    // Start is called before the first frame update
    void Start()
    {
        CurrentSpeed = BaseSpeed;

        //initialize timers
        SpawnTimer = 0f;
        EscalationTimer = 0f;
        WaveTimer = 0f;

        //set initial spawn rate
        InitialRate = SpawnRate;
    }


    // Update is called once per frame
    void Update()
    {
        if(SpawnTimer >= SpawnRate)
        {
            GameObject Instance = Instantiate(ObstacleObject, transform.position, Quaternion.identity, transform); //Spawn the obstacle
            Instance.GetComponent<Obstacle>().BlockCount = ObstacleDensity; //set the number of lasers the obstacle should create
            Instance.GetComponent<Obstacle>().Speed = CurrentSpeed; //set the obstacle's speed
            SpawnTimer = 0f; //reset timer
        }

        if(EscalationTimer >= (WaveTime / 10f)) //called in 10 increments per wave
        {
            SpawnRate -= EscalationAmount / 10; //increase the rate that obstacles are spawned at
            CurrentSpeed += SpeedModifier / 10; //increase obstacle speed
            EscalationTimer = 0f; //reset timer
        }

        if(WaveTimer >= WaveTime) //once per wave
        {
            if(ObstacleDensity == 8)
            {
                InitialRate += DifficultyScale; //permanently increase the base spawn rate by DifficultyScale. After reaching the max 'ObstacleDensity', this will continue to increase until the player loses
            }
            else
            {
                ObstacleDensity++; //increase the number of lasers spawned per obstacle (ranging from 1 to 8)
            }
            CurrentSpeed = BaseSpeed;
            SpawnRate = InitialRate;
            WaveTimer = 0f;
        }

        //Increment the timers by Time.deltaTime (the real time that passed in the previous frame)
        SpawnTimer += Time.deltaTime;
        WaveTimer += Time.deltaTime;
        EscalationTimer += Time.deltaTime;
    }
}
