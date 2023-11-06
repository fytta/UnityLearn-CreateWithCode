using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEngine.GraphicsBuffer;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPbxs;
    public float spawnInterval;
    public float startDelay;
    public int maxEnemies;
    public float[] spawnX;
    public float[] spawnZ;

    void Start()
    {
        InvokeRepeating("SpawnAnimals", startDelay, spawnInterval);
    }

    void Update()
    {
    }

    void SpawnAnimals()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            int random = Random.Range(0, animalPbxs.Length);
            Vector3 newPos = generateNewPosition();
            Debug.Log(animalPbxs.Length + " " + random);
            Instantiate(
                animalPbxs[random],
                newPos,
                animalPbxs[random].transform.rotation);
        }
    }


    private Vector3 generateNewPosition()
    {
        float randomX = Random.Range(spawnX[0], spawnX[1]);
        float randomZ = Random.Range(spawnZ[0], spawnZ[1]);
        return new Vector3(randomX, animalPbxs[0].transform.position.y, randomZ);
    }
}
