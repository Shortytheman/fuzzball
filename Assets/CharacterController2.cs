using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    public Transform target; // The object to look at (e.g., the ball)
    public float speed = 5f; // Character movement speed
    private Camera mainCamera; // Reference to the main camera
    private Rigidbody body; // Reference to the character's Rigidbody
    //public KeyCode kickKey = KeyCode.T; // Key for kicking the ball
    public float kickForce = 500f; // Force applied to the ball when kicked

    private void Start()
    {
        mainCamera = Camera.main; // Get the reference to the main camera
        body = GetComponent<Rigidbody>(); // Get the reference to the character's Rigidbody
    }

    private void Update()
    {
        if (target != null)
        {
            // Calculate the direction to move towards the target object
            Vector3 targetDirection = (target.position - transform.position).normalized;

            // Keyboard input for character movement
            float horizontalInput = 0f;
            float verticalInput = 0f;
            Vector3 movementDirection = Vector3.zero;

            // Check for input from arrow keys
            if (Input.GetKey(KeyCode.W))
            {
                verticalInput = 1f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                verticalInput = -1f;
            }

            if (Input.GetKey(KeyCode.D))
            {
                horizontalInput = 1f;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                horizontalInput = -1f;
            }

            // Calculate the movement direction based on input
            movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

            // Rotate the character towards the target object
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);

            // Move the character in the calculated direction
            transform.Translate(movementDirection * speed * Time.deltaTime, Space.Self);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            KickBall(collision.gameObject);
        }
    }

    private void KickBall(GameObject ball)
    {
        // Calculate the kick direction
        Vector3 kickDirection = ball.transform.position - transform.position;

        // Apply the kick force to the ball
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        if (ballRigidbody != null)
        {
            ballRigidbody.AddForce(kickDirection.normalized * kickForce);
        }
    }
}
