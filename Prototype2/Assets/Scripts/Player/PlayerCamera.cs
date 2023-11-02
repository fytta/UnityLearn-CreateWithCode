using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 playerOffset;


    void Start()
    {
       playerOffset = new Vector3(5f, 4f, 1f);
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + playerOffset;
    }
}
