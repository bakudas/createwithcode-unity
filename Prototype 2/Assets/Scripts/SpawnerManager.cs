using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class SpawnerManager : MonoBehaviour
{

    public GameObject[] animalsPrefabs;
    private float spawnRange = 12;
    private float spawnPosZ = 35;
    private float spawnTime = 2f;
    private float startDelay = 2f;


    private void Start()
    {
        // Invoke method by delayed time at repeat rate
        InvokeRepeating("SpawnAnimals", startDelay, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        // timer de spawn an animal
        spawnTime -= Time.deltaTime;

        
        // if (spawnTime < 0)
        // {
        //     SpawnAnimals(); // call method to create an randow animal at random xPos at top of the screen
        //     spawnTime = 2; // reset the timer
        // }

    }

    void SpawnAnimals()
    {
        // randomize animal index
        int animalIndex = Random.Range(0, animalsPrefabs.Length);
        //randomize x Pos to create an animal
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0 , spawnPosZ);
        
        // Instantiate Animal
        Instantiate(animalsPrefabs[animalIndex], spawnPos, animalsPrefabs[animalIndex].transform.rotation);
    }
}
