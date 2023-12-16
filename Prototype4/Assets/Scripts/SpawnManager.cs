using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPbx;
    public int enemyCount;
    public int waveNumber;
    public GameObject powerupPbx;

    private float spawnRange = 9;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPbx, GenerateSpawnPosition(), powerupPbx.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0 )
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPbx, GenerateSpawnPosition(), powerupPbx.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemies)
    {
        for (int i = 0; i<enemies; i++)
        {
            Instantiate(enemyPbx, GenerateSpawnPosition(), enemyPbx.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnX, 0, spawnZ);
    }
}
