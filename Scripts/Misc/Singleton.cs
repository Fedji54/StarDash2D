using UnityEngine;

namespace WinterUniverse
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T _staticInstance;
        public static T StaticInstance => _staticInstance;

        protected virtual void Awake()
        {
            if (_staticInstance == null)
            {
                _staticInstance = (T)this;
            }
            else if (_staticInstance != (T)this)
            {
                Destroy(gameObject);
                return;
            }
            if (!transform.parent)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}