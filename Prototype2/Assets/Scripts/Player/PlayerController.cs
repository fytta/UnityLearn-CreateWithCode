using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject projectilePbx;

    [SerializeField] private float speed;
    [SerializeField] private float[] bounds; 
    private float horizontalInput;
    //public Vector3 projectileOffset;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Move(horizontalInput);
        Shoot();
    }

    void Move(float horizontalInput)
    {
        if (!IsOutOfBounds(horizontalInput, transform.position.z))
        {
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }
    }

    bool IsOutOfBounds(float hInput, float position)
    {
        float newPosition = hInput + position;
        if (newPosition <= bounds[0]) return true;
        else if (newPosition >= bounds[1]) return true;
        else return false;
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Instantiate(projectilePbx, 
                new Vector3(transform.position.x, 2, transform.position.z), 
                projectilePbx.transform.rotation);
        }
    }
}
