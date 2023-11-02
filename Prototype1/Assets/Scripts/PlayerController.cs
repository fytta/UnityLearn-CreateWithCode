using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string inputID;

    private float velocity = 10;
    private float turnVelocity = 10;
    private float horizontalInput;
    private float forwardInput;


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        transform.Translate(Vector3.forward * Time.deltaTime * velocity * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnVelocity * horizontalInput);
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
