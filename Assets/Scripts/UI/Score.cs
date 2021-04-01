using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable()
    {
        _player.ScoreAdded += OnScoreAdded;
    }

    private void OnDisable()
    {
        
    }

    private void OnScoreAdded(int score)
    {
        _scoreText.text = score.ToString();
    }
}
