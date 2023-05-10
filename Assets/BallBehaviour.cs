using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float kickForce = 500f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Anime_character"))
        {
            // Disable collision between the ball and the character
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());

            // Calculate the kick direction
            Vector3 kickDirection = collision.gameObject.transform.position - transform.position;
            rb.AddForce(kickDirection.normalized * kickForce);
        }
    }
}