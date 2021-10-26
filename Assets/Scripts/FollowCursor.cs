using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private Rigidbody rb;
    private Vector3 dir;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float rotationSpeed;
    void Start(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = this.GetComponent<Rigidbody>();
        dir = Vector3.zero;
    }

    void Update()
    {

        horizontal = Input.GetAxis("Mouse X");
        vertical = Input.GetAxis("Mouse Y");

        dir = new Vector3 (horizontal, vertical, 0);
    }

    void FixedUpdate(){
        rb.velocity = dir * projectileSpeed;
    }
}
