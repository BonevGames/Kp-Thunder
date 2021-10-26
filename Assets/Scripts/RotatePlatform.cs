using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    void FixedUpdate()
    {
        transform.Rotate (0,0,speed*Time.deltaTime);
    }
}
