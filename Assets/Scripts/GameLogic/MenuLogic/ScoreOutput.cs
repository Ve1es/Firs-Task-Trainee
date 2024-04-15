using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreOutput : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Score score;

    private int _scoreInput = 0;

    private void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        SetScore();
    }

    private void SetScore()
    {
        _scoreInput = score.GetScore();
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = _scoreInput.ToString();
    }
}
