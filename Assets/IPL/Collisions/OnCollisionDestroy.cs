using System;
using UnityEngine;

public class OnCollisionDestroy : MonoBehaviour
{
    [SerializeField] private AffectedObject affectedObject;
    [SerializeField] private bool destroyOnCollision;
    [SerializeField] private bool destroyOnTrigger;
    
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (destroyOnCollision)
            DestroyObjects(other.rigidbody.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (destroyOnTrigger)
            DestroyObjects(other.attachedRigidbody.gameObject);
    }

    private void DestroyObjects(GameObject other)
    {
        switch (affectedObject)
        {
            case AffectedObject.Self:
                Destroy(gameObject);
                break;
            case AffectedObject.Other:
                Destroy(other);
                break;
            case AffectedObject.Both:
                Destroy(gameObject);
                Destroy(other);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }


    public enum AffectedObject
    {
        Self,
        Other,
        Both,
    }

}

