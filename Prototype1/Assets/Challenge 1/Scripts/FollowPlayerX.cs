using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(25.28f, 2.56f, -1.26f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = plane.transform.position + offset;
    }
}
