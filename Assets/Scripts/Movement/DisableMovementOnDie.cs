using HealthMechanics;
using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    public class DisableMovementOnDie : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private NavMeshAgent _agent;

        private void OnDestroy()
        {
            _health.Reduced -= OnReduced;
        }

        private void Start()
        {
            _health.Reduced += OnReduced;
        }

        private void OnReduced()
        {
            if (_health.IsAlive)
            {
                return;
            }
            
            _agent.enabled = false;
        }
    }
}