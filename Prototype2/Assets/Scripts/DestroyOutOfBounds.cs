using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float topBound = 30; // destroy projectiles
    private float lowerBound = -10; // destroy animals

    void Update()
    {
        if (transform.position.x > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("GAME OVER!");
            Destroy(gameObject);
        }
    }
}
