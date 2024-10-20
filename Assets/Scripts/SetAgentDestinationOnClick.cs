using System;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class SetAgentDestinationOnClick : MonoBehaviour
    {
        [SerializeField] private ClickRaycast _clickRaycast;
        [SerializeField] private NavMeshAgent _agent;

        private void OnDestroy()
        {
            _clickRaycast.Raycast -= OnRaycast;
        }

        private void Start()
        {
            _clickRaycast.Raycast += OnRaycast;
        }

        private void OnRaycast(RaycastHit hit)
        {
            _agent.SetDestination(hit.point);
        }
    }
}