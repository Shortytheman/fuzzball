using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalkeeperMovement : MonoBehaviour
{
    public Transform gokuModel;

    public float moveSpeed = 1.0f;

    public float moveRange = 5.0f;

    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = gokuModel.position;
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        gokuModel.position = new Vector3(gokuModel.position.x, gokuModel.position.y, startPos.z + movement);
    }
}
