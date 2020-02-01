using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 offset;
    public float cameraMovingSpeed;
    void Start(){
offset=transform.position;
}
    void FixedUpdate()
    {
        Vector3 newPosition=targetObject.position+offset;
        transform.position=Vector3.Lerp(transform.position,newPosition,cameraMovingSpeed);

    }
}
