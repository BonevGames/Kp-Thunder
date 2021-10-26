using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoonGoal : MonoBehaviour
{
     void OnTriggerEnter(Collider col){
         if(col.gameObject.tag == "Player"){
             Time.timeScale = 1;
             Cursor.visible = true;
             Cursor.lockState = CursorLockMode.None;
             SceneManager.LoadScene(2);
         }
     }
}
