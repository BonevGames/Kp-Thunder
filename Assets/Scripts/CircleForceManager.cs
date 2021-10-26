using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleForceManager : MonoBehaviour
{
    [SerializeField] private GameObject[] circleDetectors;
    [SerializeField] private GameObject projectile;
    public int counter;

    void Start(){
        counter = 0;
    }
    public void AddProjectileForce(bool alreadyActivated){
        if(alreadyActivated || counter >= 4){
            return;
        }else{
            counter += 1;
            projectile.GetComponent<AddForceToPlayer>().addForce += 2f;
            Debug.Log("Current Force: " + projectile.GetComponent<AddForceToPlayer>().addForce);
        }
    }
}
