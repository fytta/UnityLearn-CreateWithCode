using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerOffset;
    private bool swapCamera = false;

    // Start is called before the first frame update
    void Start()
    {
        playerOffset = new Vector3(0, 5, -7);
    }
    
    void LateUpdate()
    {
        transform.position = player.transform.position + playerOffset;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            swapCamera = !swapCamera;
            if (swapCamera) 
            {
                playerOffset = new Vector3(0, 5, -7);
            }
            else
            {
                playerOffset = new Vector3(0, 5, -3);
            }
        }
    }

}
