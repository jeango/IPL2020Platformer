using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IPL.Pooling
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject pooledObject;
        [SerializeField] private int maxActiveInstances = 2;
        private Queue<GameObject> _pool = new Queue<GameObject>(100);
        private List<GameObject> _trackedInstances = new List<GameObject>(100);
        private static Dictionary<GameObject, ObjectPool> _pools = new Dictionary<GameObject, ObjectPool>(10);

        public static ObjectPool GetPool(GameObject pooledObject)
        {
            if (_pools.TryGetValue(pooledObject, out var pool) == false)
            {
                pool = new GameObject(pooledObject.name  + " Pool", typeof(ObjectPool)).GetComponent<ObjectPool>();
                pool.pooledObject = pooledObject;
                _pools[pooledObject] = pool;
            }
            return pool;
        }

        private void Awake()
        {
            if (pooledObject)
                _pools[pooledObject] = this;
        }

        public bool TryAquire(out GameObject toAcquire)
        {
            if (_pool.Any())
            {
                toAcquire = _pool.Dequeue();
                toAcquire.SetActive(true);
                return true;
            }
            if (_trackedInstances.Count >= maxActiveInstances)
            {
                toAcquire = null;
                return false;
            }
            toAcquire = Instantiate(pooledObject);
            _trackedInstances.Add(toAcquire);
            var pooled = toAcquire.GetComponent<Pooled>();
            if (!pooled)
                pooled = toAcquire.AddComponent<Pooled>();
            pooled.pool = this;
            return true;
        }

        public bool TryRelease(GameObject toRelease)
        {
            if (toRelease.GetComponent<Pooled>()?.pool != this)
                return false;
            toRelease.SetActive(false);
            StartCoroutine(Enqueue(toRelease));
            return true;
        }

        private IEnumerator Enqueue(GameObject obj)
        {
            yield return null;
            _pool.Enqueue(obj);
        }
    }
}