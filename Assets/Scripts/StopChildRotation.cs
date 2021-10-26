using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopChildRotation : MonoBehaviour
{
private Transform player;
void Awake(){
    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
}
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + .35f, 0f);
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
