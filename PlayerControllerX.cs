using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    //explosion effects
    public GameObject explosionEffect;
    public AudioClip explosionSound;


    public float verticalInput = 10f;

    private float rotationSpeed = 100f;

    private float turnInput;
    private float horizontalInput;
    private float forwardSpeed = 20f;
    private float forwardInput;

    private float jumpheight = 100f;
    private bool canJump = true;

    private bool isGameOver = false;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        //get body componets
       playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGameOver) return; // Exit the method if the game is over

        // get the user's vertical input and horizontal inputs
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.left * forwardSpeed * Time.deltaTime);

        //make the plane constant fall 
        transform.Translate(Vector3.down * 0.1f * Time.deltaTime);
        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.left * rotationSpeed * verticalInput * Time.deltaTime);

        transform.Translate(Vector3.up * forwardSpeed * verticalInput * Time.deltaTime);

        // move plane up/down based on verticalInput
        if (verticalInput > 0 && !canJump)
        {

            canJump = true; // Prevent continuous jumping
            transform.Translate(Vector3.up * jumpheight * Time.deltaTime);
        }
        if (verticalInput <= 0)
        {
            canJump = false;// Allow jumping again when not pressing up
            // make plane fall down

        }
    }
         private void OnCollisionEnter(Collision collision)
    {
        //check if player touches wall
        if (collision.gameObject.CompareTag("Wall") && !isGameOver)
        {
 
            //explode player object
            ExplodePlayer();

        }
    }
    private void ExplodePlayer()
    {
        isGameOver = true;
        Debug.Log("Game Over!");

        if (explosionEffect!=null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position);
        }
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        if (playerRb != null)
        {

            playerRb.isKinematic = true; 
            playerRb.detectCollisions = false;
        }
        Invoke ("CompleteGameOver", 2f);
    }
   private void CompleteGameOver()
    {


        //find GameManager in scene
        GameManager gamemanger = Object.FindObjectOfType<GameManager>();
        if (gamemanger != null)
        {
            gamemanger.Gameover();
        }
        else
        {
            Debug.Log("Game Over");
            Debug.LogWarning("GameManager not found in the scene.");
        }
        Destroy(gameObject);
    }
}

