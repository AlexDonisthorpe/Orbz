using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject howToPlayCanvas;
    [SerializeField] private GameObject highScoreCanvas;

    private void Start()
    {
        AkSoundEngine.PostEvent("Menu", gameObject);
    }

    public void LoadGame()
    {
        // Assuming the game is in a 2nd scene here
        AkSoundEngine.PostEvent("MenuStop", gameObject);
        SceneManager.LoadScene(1);
    }

    public void LoadHowToPlay()
    {
        CloseSubMenus();
        howToPlayCanvas.SetActive(true);
    }

    public void LoadHighScore()
    {
        CloseSubMenus();
        highScoreCanvas.SetActive(true);
    }

    public void CloseSubMenus()
    {
        howToPlayCanvas.SetActive(false);
        highScoreCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
                    Application.OpenURL("https://www.scorespace.net/");
        #else
                    Application.Quit();
        #endif
    }

}
