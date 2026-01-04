using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public float verticalSpeed = 2f;
    public float upperRange = 20f;
    public float lowerRange = -20f;

    private Vector3 startPosition;
    private Rigidbody WallRb;
    private bool movingUp = true;
    private bool movingDown = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get body componets
        WallRb = GetComponent<Rigidbody>();

        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // move the wall up and down at a constant rate
        if (movingUp)
        {
            transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
        }
        else if (movingDown)
        {
            transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime);
        }

        // Check if the wall has reached the upper or lower range

        if (transform.position.y >= startPosition.y + upperRange)
        {
            movingUp = false;
            movingDown = true;
        }
        else if (transform.position.y <= startPosition.y + lowerRange)
        {
            movingUp = true;
            movingDown = false;
        }


    }
}
