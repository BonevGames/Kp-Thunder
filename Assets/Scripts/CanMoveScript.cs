using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMoveScript : MonoBehaviour
{
    private Player player;
    private bool canMove;
    void Awake()
    {  
       player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider col){
        if(col.gameObject.tag == "Player"){
            canMove = true;
            player.canMove = canMove;
        }
    }
    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){
            canMove = false;
            player.canMove = canMove;
        }
    }
}
