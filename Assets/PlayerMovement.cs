using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;
        if (Input.GetKey(KeyCode.W)) {
            verticalInput = 1f;
        } else if (Input.GetKey(KeyCode.S)) {
            verticalInput = -1f;
        }

        if (Input.GetKey(KeyCode.A)) {
            horizontalInput = -1f;
        } else if (Input.GetKey(KeyCode.D)) {
            horizontalInput = 1f;
        }

        Vector3 movement = new Vector3(verticalInput, 0f, -horizontalInput);

        transform.position += movement * speed * Time.deltaTime;
    }
}
