using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float speed = 10f;
    public float turnSpeed = 45f;
    public float jumpHeight = 5f; 

    private float horizontalInput;
    private float JumpInput; 
    private float forwardInput;
    private Rigidbody playerRb;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        JumpInput = Input.GetAxis("Jump");

                // first method to move object only on z axis
        // transform.Translate(0, 0, 1);

      

                //move vechile forward per secound
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        transform.Translate(Vector3.down * Time.deltaTime * speed); //gravity effect

        //turn vechile left and right
        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed *horizontalInput);
        transform.Rotate(Vector3.up,Time.deltaTime * turnSpeed * horizontalInput);
        //move vechile up and down
        transform.Translate(Vector3.up * Time.deltaTime * jumpHeight * JumpInput );
    }

   
}
