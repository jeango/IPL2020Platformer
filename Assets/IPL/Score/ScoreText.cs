using IPL;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        UpdateScore(GameManager.Instance.ScoreManager.Score);
        GameManager.Instance.ScoreManager.onScoreChange += UpdateScore;
    }

    private void UpdateScore(int value)
    {
        text.text = value.ToString();
    }
}
