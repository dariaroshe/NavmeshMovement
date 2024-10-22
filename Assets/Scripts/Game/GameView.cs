using Marker;
using Service;
using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    public class GameView : MonoBehaviour
    {
        [field: SerializeField] public NavMeshAgent PlayerAgent { get; private set; }
        [field: SerializeField] public Health PlayerHealth { get; private set; }
        [field: SerializeField] public UpdatableRunner UpdatableRunner { get; private set; }
        [field: SerializeField] public MarkerView Marker { get; private set; }
        [field: SerializeField] public Camera Camera { get; private set; }
    }
}