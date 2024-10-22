using System.Collections;
using UnityEngine;

namespace Service
{
    public class Lifetime : MonoBehaviour
    {
        [SerializeField] private float _lifetime;

        private void Start()
        {
            StartCoroutine(DestroyInTime());
        }

        private IEnumerator DestroyInTime()
        {
            yield return new WaitForSeconds(_lifetime);
            Destroy(gameObject);
        }
    }
}