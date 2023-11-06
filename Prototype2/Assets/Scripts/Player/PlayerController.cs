using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI txt;
    public GameObject projectilePbx;

    [SerializeField] private float speed;
    [SerializeField] private float[] verticalBounds; 
    [SerializeField] private float[] horizontalBounds;

    private float verticalInput;
    private float horizontalInput;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        Move(verticalInput, horizontalInput);
        Shoot();
        UpdateScore();
    }

    void Move(float verticalInput, float horizontalInput)
    {
        Vector3 currentPosition = transform.position;
        Vector3 movement = new Vector3(verticalInput * speed * Time.deltaTime * -1, 0f, horizontalInput * speed * Time.deltaTime);
        Vector3 newPosition = currentPosition + movement;
        if (!IsOutOfBounds(newPosition))
        {
            transform.position = newPosition;
        }
    }

    bool IsOutOfBounds(Vector3 newPos)
    {
        if((newPos.z < -14 || newPos.z > 34) || (newPos.x < 10 || newPos.x > 23))
        {
            return true;
        }
        return false;
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 currentPos = new Vector3(transform.position.x, 2, transform.position.z);
            GameObject projectile = ProjectilePool.instance.GetPooledObject();
            projectile.transform.position = currentPos;
            projectile.SetActive(true);
            //Instantiate(projectilePbx, 
            //    new Vector3(transform.position.x, 2, transform.position.z), 
            //    projectilePbx.transform.rotation);
        }
    }

    public void UpdateScore()
    {
        txt.text = "Score: " + score;
    }
}
