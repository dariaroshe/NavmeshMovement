using UnityEngine;
using UnityEngine.AI;

namespace Marker
{
    public class MarkerDestroyer : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private MarkerContainer _markerContainer;
        
        private void Update()
        {
            DestroyClickMarker();
        }

        private void DestroyClickMarker()
        {
            if (_markerContainer.Marker == null)
            {
                return;
            }

            if (_agent.pathPending)
            {
                return;
            }

            if (_agent.remainingDistance > _agent.stoppingDistance)
            {
                return;
            }
        
            Destroy(_markerContainer.Marker);
        }
    }
}