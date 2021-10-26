using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSetting : MonoBehaviour
{
    [SerializeField] private GameObject PPVolume;
    [SerializeField] private AudioSource musicSource, jumpSFX, bounceSFX, impactSFX;
    void Start()
    {
        if(PlayerPrefs.HasKey("GraphicsQ")){
            if(PlayerPrefs.GetInt("GraphicsQ") == 0){
                PPVolume.SetActive(true);
            }else{
                PPVolume.SetActive(false);
            }
        }

        if(PlayerPrefs.HasKey("AudioMute")){
            if(PlayerPrefs.GetInt("AudioMute") == 1){
                musicSource.volume = 0;
                jumpSFX.volume = 0;
                bounceSFX.volume = 0;
                impactSFX.volume = 0;
                Debug.Log("Mute");
            }else{
                musicSource.volume = 0.7f;
                jumpSFX.volume = 1;
                bounceSFX.volume = 1;
                impactSFX.volume = 1;
            }
        }
    }
}
