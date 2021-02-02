using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.TextCore;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private BallMovement _ball;
    [SerializeField] private List<Score> _scores = new List<Score>();

    [Serializable]
    public class Score
    {
        public string Name;
        public TMPro.TextMeshProUGUI TextReference;
        public int ScoreValue;
    };

    public void AddScore(int id, int score)
    {
        if (_scores.Count > id)
        {
            _scores[id].ScoreValue += score;
            UpdateTextValues();
            _ball.ResetBall();
        }
        else
        {
            Debug.LogWarning("Error: No score with ID: " + id + " found!");
        }
    }

    public void SetScore(int id, int score)
    {
        if (_scores.Count > id)
        {
            _scores[id].ScoreValue = score;
            UpdateTextValues();
            _ball.ResetBall();
        }
        else
        {
            Debug.LogWarning("Error: No score with ID: " + id + " found!");
        }
    }

    private void UpdateTextValues()
    {
        foreach (var score in _scores)
        {
            score.TextReference.text = score.ScoreValue.ToString();
        }
    }
}
