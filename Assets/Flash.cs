using System.Collections;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private AnimationCurve curve;
    private void OnEnable()
    {
        StartCoroutine(FadeOut());
    }

    [ContextMenu("Test")]
    private void Test()
    {
        gameObject.SetActive(true);
    }

    private IEnumerator FadeOut()
    {
        float duration = 0.5f;
        float elapsed = 0;
        var col = _renderer.color;
        while (elapsed < duration)
        {
            yield return null;
            elapsed += Time.deltaTime;
            col.a = curve.Evaluate(elapsed / duration);
            _renderer.color = col;
        }
        gameObject.SetActive(false);
    }
}
