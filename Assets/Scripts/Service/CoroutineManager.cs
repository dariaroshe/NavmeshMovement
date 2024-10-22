using System.Collections;
using UnityEngine;

namespace Service
{
    public class CoroutineManager : MonoBehaviour
    {
        private static bool _initialized;
        private static CoroutineManager _instance;

        public static void Stop(Coroutine coroutine)
        {
            if (coroutine == null)
            {
                return;
            }
            
            if (!_initialized)
            {
                Initialize();
            }

            _instance.StopCoroutine(coroutine);
        }
        
        public static Coroutine Run(IEnumerator coroutine)
        {
            if (!_initialized)
            {
                Initialize();
            }
            
            return _instance.RunInternal(coroutine);
        }

        private static void Initialize()
        {
            var instance = new GameObject("CoroutineManager");
            _instance = instance.AddComponent<CoroutineManager>();
            DontDestroyOnLoad(instance);
            
            _initialized = true;
        }

        private Coroutine RunInternal(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }
    }
}