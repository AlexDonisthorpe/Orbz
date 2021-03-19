using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] uint currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI multiplierText;

    int currentMultipler = 1;

    public void UpdateScore(float scoreToAdd)
    {
        currentScore += (uint)Mathf.RoundToInt(scoreToAdd*currentMultipler);
        UpdateScoreText();

        currentMultipler++;
        UpdateMultiplierText();
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
}