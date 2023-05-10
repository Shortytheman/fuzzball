using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
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

        if (Input.GetKey(KeyCode.UpArrow)) {
            verticalInput = 1f;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            verticalInput = -1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            horizontalInput = -1f;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            horizontalInput = 1f;
        }

        Vector3 movement = new Vector3(-verticalInput, 0f, horizontalInput);

        transform.position += movement * speed * Time.deltaTime;
    }
}
