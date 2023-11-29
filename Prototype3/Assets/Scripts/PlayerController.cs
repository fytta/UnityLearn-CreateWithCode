using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip crashSound;
    public AudioClip jumpSound;

    public float jumpForce;
    public float gravityModifier;
    public bool gameOver;

    private AudioSource playerAudio;
    private Rigidbody playerRb;
    private bool onGround = true;
    private Animator playerAnim;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround && !gameOver)
        {
            onGround = false;
            MovePlayerCommand(Vector3.up * jumpForce);
            playerAudio.PlayOneShot(jumpSound, 1f);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    
    }


    public void Move(Vector3 move)
    {
        playerRb.AddForce(move, ForceMode.Impulse);
    }

    private void MovePlayerCommand(Vector3 move)
    {
        ICommand command = new MoveCommand(this, move);
        CommandInvoker.ExecuteCommand(command);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound, 1f);
            explosionParticle.Play();

            while (CommandInvoker.undoStack.Count > 0) //TODO: NOT WORKING UNDO
            {
                CommandInvoker.UndoCommand(); 
            }
            Debug.Log("Game Over");
        }
        else
        {
            dirtParticle.Stop();
        }
    }
}
