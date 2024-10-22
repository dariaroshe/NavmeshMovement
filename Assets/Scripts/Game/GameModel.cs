using Service;
using UnityEngine;

namespace Game
{
    public class GameModel
    {
        public EventField<Vector3> MovePlayer { get; } = new();
    }
}