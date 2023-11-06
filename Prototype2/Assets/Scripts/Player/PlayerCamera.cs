using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 playerOffset;


    void Start()
    {
       playerOffset = new Vector3(-25f, 67f, -24f);
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + playerOffset;
    }
}
