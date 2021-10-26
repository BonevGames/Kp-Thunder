using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject thisPanel;
    [SerializeField] ActivateProjectile filterAP;
    void Start()
    {
        thisPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !thisPanel.activeSelf){
            Time.timeScale = 0;
            thisPanel.SetActive(true);
            filterAP.itsPaused = true;
        }else if(Input.GetKeyDown(KeyCode.Escape) && thisPanel.activeSelf){
            Time.timeScale = 1;
            filterAP.itsPaused = false;
            thisPanel.SetActive(false);
        }else if(Input.GetKeyDown(KeyCode.Q) && thisPanel.activeSelf){
            Time.timeScale = 1;
            Cursor.visible = true;
            filterAP.itsPaused = false;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
            
        }
    }
}
