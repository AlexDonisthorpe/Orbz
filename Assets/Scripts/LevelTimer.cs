using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] float levelDuration = 100;
    [SerializeField] Slider slider;
    [SerializeField] private GameObject gameOverCanvas;

    private float _startTime;
    private bool _started = false;

    public delegate void Timer();
    public static event Timer TimeUp;

    public void StartLevel()
    {
        AkSoundEngine.PostEvent("MenuStop", gameObject);
        _startTime = Time.timeSinceLevelLoad;
        _started = true;
        FindObjectOfType<SphereManager>().StartGame();
        AkSoundEngine.PostEvent("MUSIC", gameObject);
        
       

    }

    private void Update()
    {
        if (_started)
        {
            float timeRemaining = (Time.timeSinceLevelLoad - _startTime) / levelDuration;
            slider.value = timeRemaining;

            if(timeRemaining >= 1)
            {
                _started = false;
                EndLevel();
            }
        }
    }

    private void EndLevel()
    {
        TimeUp();
        gameOverCanvas.SetActive(true);
        AkSoundEngine.PostEvent("MUSICSTOP", gameObject);
        AkSoundEngine.PostEvent("Menu", gameObject);
    }
}
