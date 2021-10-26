using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDetection : MonoBehaviour
{
    public bool activated;
    [SerializeField] private CircleForceManager cfm;
    
    void Start(){
        activated = false;
    }
    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Projectile"){
            if(activated){
            }
            cfm.AddProjectileForce(activated);
        }
    }
}
