using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    private Vector3[] characterStartPositions;
    private Vector3 ballStartPosition;

    private void Start()
    {
        // Store the starting positions of characters and ball
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");
        characterStartPositions = new Vector3[characters.Length];
        for (int i = 0; i < characters.Length; i++)
        {
            characterStartPositions[i] = characters[i].transform.position;
        }

        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        ballStartPosition = ball.transform.position;
    }

    private void ResetCharacters()
    {
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].transform.position = characterStartPositions[i];
        }
    }

    private void ResetBall()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        ball.transform.position = ballStartPosition;
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Goal!");
            ResetCharacters();
            ResetBall();
        }
    }
}
