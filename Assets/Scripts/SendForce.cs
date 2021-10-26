using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendForce : MonoBehaviour
{
    public Vector3 direction;
    public float angle;
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Projectile"){
           col.gameObject.GetComponent<AddForceToPlayer>().PushPlayer(direction, angle);
        }
    }
}
