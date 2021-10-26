using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsRandomZPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Random.Range(50,300));
    }

}
