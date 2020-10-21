using IPL.Pooling;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawner;
    [SerializeField] private float projectileSpeed;

    public void Fire()
    {
        if (projectilePrefab.TryAcquire(out var projectile) == false)
            return;
        var t = projectile.transform;
        t.position = projectileSpawner.position;
        t.rotation = projectileSpawner.rotation;
        var rb = projectile.GetComponent<Rigidbody2D>();
        if (rb)
           rb.velocity = projectileSpawner.right * projectileSpeed;
        projectile.layer = gameObject.layer;
    }
}
