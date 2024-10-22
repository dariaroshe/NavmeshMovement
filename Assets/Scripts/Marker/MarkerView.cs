using UnityEngine;

namespace Marker
{
    public class MarkerView : MonoBehaviour
    {
        [field: SerializeField] public GameObject ClickMarkerPrefab { get; private set; }
    }
}