using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowProjectile : MonoBehaviour
{
    [SerializeField] private GameObject projectileVisuals;
    void Start()
    {
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(projectileVisuals.activeSelf){
            transform.position = new Vector3(projectileVisuals.transform.position.x, projectileVisuals.transform.position.y, 0f);
        }else{
            transform.position = Vector3.zero;
        }
    }
}
