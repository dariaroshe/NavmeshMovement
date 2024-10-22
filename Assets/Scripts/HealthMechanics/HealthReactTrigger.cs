using System;
using UnityEngine;

namespace HealthMechanics
{
    public class HealthReactTrigger : MonoBehaviour
    {
        public event Action<Health> Enter;
        public event Action<Health> Exit;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Health>(out var health))
            {
                Enter?.Invoke(health);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Health>(out var health))
            {
                Exit?.Invoke(health);
            }
        }
    }
}