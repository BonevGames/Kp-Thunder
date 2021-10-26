using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiTextManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Color32 desiredColor;
    private Text text;
    [SerializeField] private bool playGame, audioMute, lowGraphics, exitGame, fullScreen;
    [SerializeField] private string ogText, altText;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private GameObject PPVolume;

    private void Awake(){
        text = this.GetComponent<Text>();
        
        if(audioMute){
            if(PlayerPrefs.HasKey("AudioMute")){
                if(PlayerPrefs.GetInt("AudioMute") == 1){
                    musicSource.volume = 0;
                    text.text = altText;
                }
            }
        }

        if(lowGraphics){
            if(PlayerPrefs.HasKey("GraphicsQ")){
                if(PlayerPrefs.GetInt("GraphicsQ" ) == 1){
                    PPVolume.SetActive(false);
                    text.text = altText;
                }
            }
        }

        if(fullScreen){
            if(PlayerPrefs.HasKey("ScreenMode")){
                if(PlayerPrefs.GetInt("ScreenMode") == 1){
                    Screen.fullScreen = false;
                    text.text = altText;
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData){
        text.color = desiredColor;
        text.fontSize = 50;
    }
    public void OnPointerExit(PointerEventData eventData){
        text.color = Color.white;
        text.fontSize = 40;
    }
    public void OnPointerClick(PointerEventData eventData){

        if(exitGame){
            Application.Quit();
        }
        if(playGame){
            SceneManager.LoadScene(1);
        }

        if(audioMute){
            int isMuted = 0;
            if(!PlayerPrefs.HasKey("AudioMute")){
                PlayerPrefs.SetInt("AudioMute", 0);
            }else{
                isMuted = PlayerPrefs.GetInt("AudioMute");
            }

            if(isMuted == 0){
                text.text = altText;
                PlayerPrefs.SetInt("AudioMute", 1);
                musicSource.volume = 0;
            }else{
                text.text = ogText;
                PlayerPrefs.SetInt("AudioMute", 0);
                musicSource.volume = 1;
            }
        }

        if(lowGraphics){
            int isGraphics = 0;
            if(!PlayerPrefs.HasKey("GraphicsQ")){
                PlayerPrefs.SetInt("GraphicsQ", 0);
            }else{
                isGraphics = PlayerPrefs.GetInt("GraphicsQ");
            }

            if(isGraphics == 0){
                PPVolume.SetActive(false);
                PlayerPrefs.SetInt("GraphicsQ", 1);
                text.text = altText;
            }else{
                PPVolume.SetActive(true);
                PlayerPrefs.SetInt("GraphicsQ", 0);
                text.text = ogText;
            }
        }

        if(fullScreen){
            int isFullScreen = 0;
            if(!PlayerPrefs.HasKey("ScreenMode")){
                PlayerPrefs.SetInt("ScreenMode", 0);
            }else{
                isFullScreen = PlayerPrefs.GetInt("ScreenMode");
            }
            if(isFullScreen == 0){
                PlayerPrefs.SetInt("ScreenMode", 1);
                text.text = altText;
                Screen.fullScreen = false;
            }else{
                PlayerPrefs.SetInt("ScreenMode", 0);
                text.text = ogText;
                Screen.fullScreen = true;
            }
        }
        PlayerPrefs.Save();
    }
}