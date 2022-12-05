using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public float xOffset = 1f;
    public float yOffset = 1f;
    public float zOffset = 1f;
    public Transform target;

    private void Update() 
    {
        Vector3 newPos = new Vector3(target.position.x+xOffset, target.position.y+yOffset, zOffset);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed*Time.deltaTime);
    }
}
