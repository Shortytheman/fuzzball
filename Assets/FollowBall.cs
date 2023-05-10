using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    
    public Transform target; // The object to look at

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // Make the camera look at the target object
            transform.LookAt(target);
        }
    }
}



