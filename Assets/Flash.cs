using System.Collections;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sound;
    private void OnEnable()
    {
        audioSource.PlayOneShot(sound);
        StartCoroutine(PlayFlash());
    }

    [ContextMenu("Test")]
    private void Test()
    {
        gameObject.SetActive(true);
    }

    private IEnumerator PlayFlash()
    {
        float duration = 1f;
        float elapsed = 0;
        var col = sprite.color;
        while (elapsed < duration)
        {
            yield return null;
            elapsed += Time.deltaTime;
            col.a = curve.Evaluate(elapsed / duration);
            sprite.color = col;
        }
        gameObject.SetActive(false);
    }
}
