using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded;
    public bool alreadyHit;
    public float jumpForce;
    [SerializeField] private AddForceToPlayer addForceToPlayer;
    [SerializeField] private Transform rotationWanted;
    private bool resetRotation;
    public bool sliding;
    public float tempRay;
    public bool canMove, isJumping, alreadyJumped;
    private float mH;
    private Animator anim;
    private AudioSource bounceSFX;
    private AudioSource jumpSFX;
    [SerializeField] private Transform rayCastPos;
    public float rayCastLength;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        bounceSFX = GameObject.FindGameObjectWithTag("BounceSfx").GetComponent<AudioSource>();
        jumpSFX = this.GetComponent<AudioSource>();
    }
    void Update(){
        /*
        RaycastHit hit;
        if(Physics.Raycast(rayCastPos.position, transform.TransformDirection(new Vector3(-1,-1,0)), out hit, rayCastLength) && hit.collider.gameObject.tag == "Projectile"){
            hit.collider.gameObject.GetComponent<AddForceToPlayer>().PushPlayer(new Vector3(-1,1,0), 45);
        }if(Physics.Raycast(rayCastPos.position, transform.TransformDirection(new Vector3(1,-1,0)), out hit, rayCastLength) && hit.collider.gameObject.tag == "Projectile"){
            hit.collider.gameObject.GetComponent<AddForceToPlayer>().PushPlayer(new Vector3(1,1,0), -45);
        }if(Physics.Raycast(rayCastPos.position, transform.TransformDirection(new Vector3(-1,1,0)), out hit, rayCastLength) && hit.collider.gameObject.tag == "Projectile"){
            hit.collider.gameObject.GetComponent<AddForceToPlayer>().PushPlayer(new Vector3(-1,-1,0), 135);
        }if(Physics.Raycast(rayCastPos.position, transform.TransformDirection(new Vector3(1,1,0)), out hit, rayCastLength) && hit.collider.gameObject.tag == "Projectile"){
            hit.collider.gameObject.GetComponent<AddForceToPlayer>().PushPlayer(new Vector3(1,-1,0), -135);
        }
        */
        
        mH = Input.GetAxisRaw("Horizontal");
        isJumping = Input.GetButtonDown("Jump");
        if(isJumping && !alreadyHit && canMove && !alreadyJumped){
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce);
            alreadyJumped = true;
        }

    }
    void FixedUpdate()
    {
        if(!alreadyHit && canMove){
            rb.velocity = new Vector3(mH * 5f, rb.velocity.y, rb.velocity.z);
        }
        if(alreadyHit){
            transform.Rotate (0,1000*Time.deltaTime,0);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        transform.localScale = Vector3.one;
        if(!alreadyHit){
            transform.rotation = Quaternion.Lerp(transform.rotation, rotationWanted.rotation, Time.deltaTime * 15f);
            resetRotation = true;
        }
        if(isGrounded){
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce / 2);
            isGrounded = false;
            alreadyHit = false;
            rb.angularVelocity = Vector3.zero;
            alreadyJumped = false;
            jumpSFX.Play();
        }
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Ground"){
            isGrounded = true;
        }
        if(col.gameObject.tag == "BounceWall"){
            rb.AddForce(rb.velocity.normalized * 2, ForceMode.Impulse);
            alreadyHit = false;
            bounceSFX.Play();
        }
    }

    public IEnumerator ResetPlayer(){
        yield return new WaitForSeconds(0.3f);
        this.GetComponent<Rigidbody>().useGravity = true;
        addForceToPlayer.hit = false;
    }
    
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rayCastPos.position + (new Vector3(-1,-1,0) * rayCastLength), .4f);
    }
}
