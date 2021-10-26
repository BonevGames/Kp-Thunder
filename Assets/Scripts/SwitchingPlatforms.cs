using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingPlatforms : MonoBehaviour
{
    [SerializeField] private GameObject[] platformsToSwitch;
    private int amount;
    private int currentPlatform;
    void Start()
    {
        amount = platformsToSwitch.Length;
        currentPlatform = 0;

        foreach(GameObject platform in platformsToSwitch){
            platform.SetActive(false);
        }
        platformsToSwitch[currentPlatform].SetActive(true);
    }
    public void ChangePlatform(){
        platformsToSwitch[currentPlatform].SetActive(false);
        currentPlatform += 1;
        if(currentPlatform == platformsToSwitch.Length){
            currentPlatform = 0;
        }
        platformsToSwitch[currentPlatform].SetActive(true);
    }
}
