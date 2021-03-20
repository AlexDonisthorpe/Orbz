using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputObject;
    [SerializeField] private TextMeshProUGUI scoreText;

    private uint score;

    private void Start()
    {
        score = FindObjectOfType<ScoreManager>().GetScore();
        scoreText.text = score.ToString();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        // Assuming Menu is scene 0
        SceneManager.LoadScene(0);
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

    public void AddScore()
    {
        string username = inputObject.text;

        Debug.Log($"{username} : {score.ToString()}");
        // Create ScoreData & Add Score;
    }

}