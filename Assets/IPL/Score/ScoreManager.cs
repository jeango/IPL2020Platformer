using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _currentScore;
    [SerializeField] private int _hiScore;
    public Action<int> onScoreChange;
    public int Score => _currentScore;

    private void Awake()
    {
        _currentScore = 0;
        _hiScore = PlayerPrefs.GetInt("HiScore");
    }

    private void OnDisable()
    {
        Save();
        _currentScore = 0;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("HiScore", _hiScore);
    }

    public void SetScore(int score)
    {
        _currentScore = score;
        _hiScore = _currentScore > _hiScore ? _currentScore : _hiScore;
        onScoreChange(_currentScore);
    }

    public void AddScore(int value)
    {
        SetScore(_currentScore + value);
    }
}