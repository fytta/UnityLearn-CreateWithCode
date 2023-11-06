using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float lowerBound = 24; // destroy animals
    private float topBound = -40; // destroy projectiles

    void Update()
    {
        if (gameObject.tag.Equals("Projectile") && transform.position.x < topBound)
        {
            gameObject.SetActive(false);
        }

        if (gameObject.tag.Equals("Animal") && transform.position.x > lowerBound)
        {
            Debug.Log("GAME OVER!");
            Destroy(gameObject);
        }
    }
}
