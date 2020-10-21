using IPL;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int points;

    public void ScorePoints()
    {
        GameManager.Instance.ScoreManager.AddScore(points);
    }
}