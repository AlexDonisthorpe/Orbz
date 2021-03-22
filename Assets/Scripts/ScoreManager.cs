using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] ulong currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI multiplierText;

    int currentMultipler = 1;

    public void UpdateScore(float scoreToAdd)
    {
        currentScore += (uint)Mathf.RoundToInt(scoreToAdd * currentMultipler);
        UpdateScoreText();

        currentMultipler++;
        UpdateMultiplierText();

        HandleMusicTriggers();
    }

    private void HandleMusicTriggers()
    {
        // Handle Music Triggers
        int currentState = 0;
        if (currentState == 0 && currentScore > 5500)
        {
            AkSoundEngine.PostEvent("SETSTATE", gameObject);
            currentState = 1;
        }

        if (currentState == 1 && currentScore > 6000000)
        {
            AkSoundEngine.PostEvent("SETSTATE2", gameObject);
            currentState = 2;
        }

        if (currentState == 2 && currentScore > 3000000000)
        {
            AkSoundEngine.PostEvent("SETSTATE3", gameObject);
            currentState = 3;
        }

        if (currentState == 3 && currentScore > 3000000000000)
        {
            AkSoundEngine.PostEvent("SETSTATE4", gameObject);
            currentState = 4;
        }

        if (currentState == 4 && currentScore > 400000000000000)
        {
            AkSoundEngine.PostEvent("SETSTATE5", gameObject);
            currentState = 5;
        }

        if (currentState == 5 && currentScore > 500000000000000000)
        {
            AkSoundEngine.PostEvent("SETSTATE6", gameObject);
            currentState = 6;
        }
    }

    public void DoubleScore()
    {
        currentScore = currentScore * 2;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    public void ResetMultiplyer()
    {
        currentMultipler = 1;
        UpdateMultiplierText();
    }

    private void UpdateMultiplierText()
    {
        multiplierText.text = "x" + currentMultipler.ToString();
    }

    public ulong GetScore()
    {
        return currentScore;
    }
}
