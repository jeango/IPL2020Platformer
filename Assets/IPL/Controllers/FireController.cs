using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawner;
    [SerializeField] private float projectileSpeed;

    public void Fire()
    {
        var projectile = Instantiate(projectilePrefab, projectileSpawner.position, projectileSpawner.rotation);
        var rb = projectile.GetComponent<Rigidbody2D>();
        if (rb)
           rb.velocity = projectileSpawner.right * projectileSpeed;
        projectile.layer = gameObject.layer;
    }
}
