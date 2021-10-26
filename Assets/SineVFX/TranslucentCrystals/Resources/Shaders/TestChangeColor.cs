using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChangeColor : MonoBehaviour
{
    private Color32 color1,color2,color3, result;
    void Start(){
        this.GetComponent<Renderer>().sharedMaterial.SetColor("_ColorTint2", Color.white);
        this.GetComponent<Renderer>().sharedMaterial.SetColor("_EmissionColor", Color.white);
        color1 = new Color32(167,245,184, 255);
        color2 = new Color32(190,76,187, 255);
        color3 = new Color32(45,48,186,255);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.L)){
            result = CombineColors(color3,color3);
            Debug.Log(result);
            this.GetComponent<Renderer>().sharedMaterial.SetColor("_ColorTint2", result);
            this.GetComponent<Renderer>().sharedMaterial.SetColor("_EmissionColor", result);
        }
    }


    public static Color CombineColors(params Color[] aColors)
        {
            Color result = new Color(0,0,0,0);
            foreach(Color c in aColors)
            {
                result += c;
            }
            result /= aColors.Length;
            return result;
        }
}
