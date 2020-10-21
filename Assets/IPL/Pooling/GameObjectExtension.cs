using UnityEngine;

namespace IPL.Pooling
{
    public static class GameObjectExtension
    {
        public static bool TryAcquire(this GameObject that, out GameObject toAquire)
        {
            return ObjectPool.GetPool(that).TryAquire(out toAquire);
        }

        public static bool TryRelease(this GameObject that)
        {
            var pooled = that.GetComponent<Pooled>();
            if (pooled?.TryRelease() == true)
                return true;
            UnityEngine.Object.Destroy(that);
            return false;
        }
    }
}