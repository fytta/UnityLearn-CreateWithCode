using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject propeller;
    public Rigidbody rb;
    private Vector3 direction;
    public float horizontalSpeed;
    public float rotationSpeed;
    private float verticalInput;
    private float propellerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3();
        propellerSpeed = 250;
    }

    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        // transform.Translate(Vector3.forward * horizontalSpeed * Time.deltaTime);
        // rb.AddForce(direction.normalized * horizontalSpeed, ForceMode.Acceleration); // con fisicas
        rb.MovePosition(rb.position + direction.normalized * horizontalSpeed * Time.deltaTime); // con fisicas pero como el transform

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right, verticalInput * rotationSpeed * Time.deltaTime);

        // propeller spinning
        propeller.transform.Rotate(Vector3.forward, propellerSpeed * Time.deltaTime);
    }
}
