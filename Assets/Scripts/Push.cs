using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    private Player player;
    [SerializeField] private bool up;
    [SerializeField] private bool down;
    [SerializeField] private bool left;
    [SerializeField] private bool right;
    [SerializeField] private float force;
    [SerializeField] private bool canJumpAfter;
    private AudioSource bounceSFX;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        bounceSFX = GameObject.FindGameObjectWithTag("BounceSfx").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject == player.gameObject){
            bounceSFX.Play();
            Rigidbody playerRb = col.gameObject.GetComponent<Rigidbody>();
            if(up){
                playerRb.AddForce(Vector3.up * force, ForceMode.VelocityChange);
            }else if(down){
                playerRb.AddForce(Vector3.down * force, ForceMode.VelocityChange);
            }
            if(left){
                playerRb.AddForce(Vector3.right * force, ForceMode.VelocityChange);
            }else if(right){
                playerRb.AddForce(Vector3.left * force, ForceMode.VelocityChange);
            }
            if(!canJumpAfter){
                player.alreadyHit = true;
            }
        }
    }
}
