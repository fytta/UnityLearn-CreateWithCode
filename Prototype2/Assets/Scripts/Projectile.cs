using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int endMapX;
    public float speed;

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (IsOutOfMap())
        {
            Destroy(gameObject);
        }
    }

    bool IsOutOfMap()
    {
        return transform.position.x > endMapX;
    }
}
