using System;
using UnityEngine;
using IPL.Pooling;

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
                gameObject.TryRelease();
                break;
            case AffectedObject.Other:
                other.TryRelease();
                break;
            case AffectedObject.Both:
                gameObject.TryRelease();
                other.TryRelease();
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

