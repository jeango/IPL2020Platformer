using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private int _currentScore;
    [SerializeField] private int _hiScore;

    private void Awake()
    {
        SetScore(0);
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
        text.text = _currentScore.ToString();
    }

    public void AddScore(int value)
    {
        SetScore(_currentScore + value);
    }
}