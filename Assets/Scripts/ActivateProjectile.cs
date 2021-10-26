using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateProjectile : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform projectilePos;
    [SerializeField] private Player playerAlreadyHit;
    [SerializeField] private Animator camShakeAnimator;
    public bool itsPaused;
    private AudioSource impactSfx;
    private bool alreadyPlaySound;
    void Start(){
        projectile.gameObject.SetActive(false);
        impactSfx = this.GetComponent<AudioSource>();
    }
    void Update(){
        if((Input.GetMouseButtonDown(0) && !playerAlreadyHit.alreadyHit) && !itsPaused){
            projectile.SetActive(true);
            SlowMotion();

            //foreach(GameObject onlyCircle in CircleObjects){
            //    onlyCircle.SetActive(true);
            //}

            projectile.transform.position = projectilePos.position;
        }
        if((Input.GetMouseButtonUp(0) || playerAlreadyHit.alreadyHit) && !itsPaused){
            NormalSpeed();
            //foreach(GameObject onlyCircle in CircleObjects){
            //    onlyCircle.SetActive(false);
            //}
        }
    }

    public void SlowMotion(){
        Time.timeScale = 0.2f;
        alreadyPlaySound = false;
    }

    public void NormalSpeed(){
        if(!alreadyPlaySound && playerAlreadyHit.alreadyHit){
            impactSfx.Play();
            alreadyPlaySound = true;
            camShakeAnimator.SetTrigger("ShakeTrigger");
        }
        projectile.SetActive(false);
        Time.timeScale = 1f;
    }
}
