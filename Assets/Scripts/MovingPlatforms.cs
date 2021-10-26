using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] private GameObject main;
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    [SerializeField] private float movingSpeed;
    private Vector3 nextPos;
    void Start()
    {
        nextPos = pos1.position;
        main.transform.position = nextPos;
    }

    void FixedUpdate()
    {
        if(main.transform.position == pos1.position){
            nextPos = pos2.position;
        }
        if(main.transform.position == pos2.position){
            nextPos = pos1.position;
        }
        main.transform.position = Vector3.MoveTowards(main.transform.position, nextPos, movingSpeed * Time.deltaTime);
    }
}
