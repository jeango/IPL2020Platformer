using UnityEngine;

namespace IPL
{
    public abstract class SingletonMb<T> : MonoBehaviour where T : SingletonMb<T>
    {
        [SerializeField] private bool persistent;
        private static T _instance;
        public static T Instance => GetInstance();

        public static T GetInstance()
        {
            if (_instance == null)
            {
                var t = typeof(T);
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                    _instance = new GameObject(t.ToString(), t).GetComponent<T>();
            }
            return _instance;
        }

        private bool InitInstance()
        {
            if (!_instance)
            {
                _instance = (T) this;
            }
            return ReferenceEquals(this, _instance);
        }
        
        protected void Awake()
        {
            if (InitInstance() == false)
            {
                Debug.LogWarningFormat(this, "An instance of <b><color=red>{0}</color></b> already exists on the scene.\r\n" +
                                             "The new instance was automatically destroyed", typeof(T));
                Destroy(gameObject);
                return;
            }
            if (persistent)
                DontDestroyOnLoad(gameObject);
            Initialize();
        }

        protected void OnDisable()
        {
            Cleanup();
            if (ReferenceEquals(this, _instance))
            {
                _instance = null;
                Destroy(gameObject);
            }
        }

        protected abstract void Cleanup();

        protected abstract void Initialize();
        
    }
}