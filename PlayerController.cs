using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float speed = 30f;
    public float turnSpeed = 45f;
    public float jumpHeight = 10f; 

    private float horizontalInput;
    private float JumpInput; 
    private float forwardInput;
    private Rigidbody playerRb;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.useGravity = true;
        playerRb.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        JumpInput = Input.GetAxis("Jump");


      

                //move vechile forward per secound
       transform.Translate(Vector3.forward  * speed * forwardInput * Time.deltaTime);

    

        //turn vechile left and right
        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed *horizontalInput);
        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
        //move vechile up and down
        transform.Translate(Vector3.up  * jumpHeight * JumpInput * Time.deltaTime);
    }
   
}
