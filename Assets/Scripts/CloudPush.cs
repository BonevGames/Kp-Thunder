using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPush : MonoBehaviour
{
    private Player player;
    [SerializeField] private bool up;
    [SerializeField] private bool down;
    [SerializeField] private bool left;
    [SerializeField] private bool right;
    [SerializeField] private float forceUpDown;
    [SerializeField] private float forceLeftRight;
    private AudioSource bounceSFX;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        bounceSFX = GameObject.FindGameObjectWithTag("BounceSfx").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject == player.gameObject){
            Rigidbody playerRb = col.gameObject.GetComponent<Rigidbody>();
            playerRb.velocity = Vector3.zero;
            bounceSFX.Play();
            if(up){
                playerRb.AddForce(Vector3.up * forceUpDown, ForceMode.VelocityChange);
            }else if(down){
                playerRb.AddForce(Vector3.down * forceUpDown, ForceMode.VelocityChange);
            }
            if(left){
                playerRb.AddForce(Vector3.right * forceLeftRight, ForceMode.VelocityChange);
            }else if(right){
                playerRb.AddForce(Vector3.left * forceLeftRight, ForceMode.VelocityChange);
            }
        }
    }
}
