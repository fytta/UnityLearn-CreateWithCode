using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePbx;
    public float startDelay = 2;
    public float repeatRate = 2;

    private PlayerController playerControllerScript;
    private Vector3 spawnPos = new Vector3(25, 0, 0);


    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePbx, spawnPos, obstaclePbx.transform.rotation);
        }
    }
}
