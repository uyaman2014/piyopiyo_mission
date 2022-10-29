using UnityEngine;

namespace keigo.Scripts.Common
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                _instance ??= new GameObject().AddComponent<T>();
                return _instance;
            }
        }

        private void OnDestroy()
        {
            _instance = null;
        }
    }
}