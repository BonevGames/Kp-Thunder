using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceToPlayer : MonoBehaviour
{
    public float addForce;
    [SerializeField] private ActivateProjectile activateProjectile;
    private Rigidbody rbPlayer;
    private Vector2 dir;
    public bool hit;
    [SerializeField] private GameObject[] switchingPlatforms;

    void Awake(){
        rbPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    public void PushPlayer(Vector3 pushDir, float rotationDir){
        activateProjectile.NormalSpeed();
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().alreadyHit){
            return;
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().alreadyHit = true;
        rbPlayer.useGravity = false;
        rbPlayer.velocity = Vector3.zero;
        rbPlayer.angularVelocity = Vector3.zero;
        rbPlayer.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0f);
        foreach(GameObject switchPlatform in switchingPlatforms){
        switchPlatform.GetComponent<SwitchingPlatforms>().ChangePlatform();
        rbPlayer.gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotationDir);
        rbPlayer.AddForce(pushDir * addForce, ForceMode.VelocityChange);
        rbPlayer.gameObject.GetComponent<Player>().StartCoroutine("ResetPlayer");
        }
    }
    /*private void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Player"){
            if(!col.gameObject.GetComponent<Player>().alreadyHit){
                activateProjectile.NormalSpeed();
                col.gameObject.GetComponent<Player>().alreadyHit = true;
                rbPlayer = col.gameObject.GetComponent<Rigidbody>();
                dir = transform.position - col.gameObject.transform.position;
                dir = dir *-1;
                rbPlayer.useGravity = false;
                rbPlayer.velocity = Vector3.zero;
                rbPlayer.angularVelocity = Vector3.zero;
                rbPlayer.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0f);
                foreach(GameObject switchPlatform in switchingPlatforms){
                    switchPlatform.GetComponent<SwitchingPlatforms>().ChangePlatform();
                }
                if(dir.x > 0){
                    if(dir.y > 0){
                        rbPlayer.gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -45f);
                        rbPlayer.AddForce(new Vector3(1f,1f,0f) * addForce, ForceMode.VelocityChange);
                    }else{
                        rbPlayer.gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -135f);
                        rbPlayer.AddForce(new Vector3(1f,-1f,0f) * addForce, ForceMode.VelocityChange);
                    }
                }else{
                    if(dir.y > 0){
                        rbPlayer.gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 45f);
                        rbPlayer.AddForce(new Vector3(-1f,1f,0f) * addForce, ForceMode.VelocityChange);
                    }else{
                        rbPlayer.gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 135f);
                        rbPlayer.AddForce(new Vector3(-1f,-1f,0f) * addForce, ForceMode.VelocityChange);
                    }
                }
                col.gameObject.GetComponent<Player>().StartCoroutine("ResetPlayer");
            }
        }
    }*/
}