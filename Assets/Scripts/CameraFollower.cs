using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private GameObject target;
    void Start()
    {
        target = GameObject.Find("Jovian");
    }

    
    void Update()
    {
        Vector3 targetPosition = target.transform.position;
        targetPosition.y += 200f; 
        transform.position = targetPosition;
    }
}
