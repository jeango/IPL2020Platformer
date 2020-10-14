using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int value;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.attachedRigidbody.GetComponent<IDamageable>()?.TakeDamage(value);
    }
}