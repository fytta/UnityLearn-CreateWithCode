using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject ballPbx;  // Prefab de la esfera que se instanciar�
    public Vector3 spawnPosition;  // Posici�n inicial de la esfera
    public Transform ball;         // Referencia a la esfera actual
    public float moveSpeed = 5f;   // Velocidad de movimiento horizontal

    private Rigidbody _rb;
    private bool _start;

    private void Start()
    {
        // Inicializa la posici�n de spawn a la posici�n actual de la esfera
        spawnPosition = ball.position;

        // Obtener el componente Rigidbody de la esfera
        _rb = ball.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_rb == null) return;

        if (Input.GetKeyUp(KeyCode.Space))
       {
            _start = true;
            _rb.useGravity = true;
        }
        else if(!_start)
        {
            float moveInput = Input.GetAxis("Horizontal");
            Vector3 move = new Vector3(_rb.velocity.x, _rb.velocity.y, moveInput * moveSpeed);
            _rb.velocity = move;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si la esfera toca el suelo
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Goal"))
        {
            ResetBall();
        }
    }

    private void ResetBall()
    {
        _start = false;
        // Restablece la posici�n y la velocidad del Rigidbody
        transform.position = spawnPosition;
        _rb.velocity = Vector3.zero; // Restablece la velocidad
        _rb.angularVelocity = Vector3.zero; // Restablece la rotaci�n

        // Opcional: Puedes desactivar la gravedad si lo deseas
        _rb.useGravity = false;
    }
}
