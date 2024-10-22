using Service;
using UnityEngine;

namespace Marker
{
    public class MarkerSpawner : MonoBehaviour
    {
        [SerializeField] private ClickRaycast _clickRaycast;
        [SerializeField] private GameObject _clickMarkerPrefab;
        [SerializeField] private MarkerContainer _markerContainer;

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
            if (_markerContainer.Marker != null)
            {
                Destroy(_markerContainer.Marker);
            }
        
            _markerContainer.Marker = Instantiate(_clickMarkerPrefab, hit.point, Quaternion.identity);
        }
    }
}