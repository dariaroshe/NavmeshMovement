using Service;
using UnityEngine;

namespace ExplosiveObjects
{
    public class DestroyExplosiveObjectController : IController
    {
        private readonly EventField _exploded;
        private readonly GameObject _gameObject;

        public DestroyExplosiveObjectController(EventField exploded, GameObject gameObject)
        {
            _exploded = exploded;
            _gameObject = gameObject;
        }

        public void Deactivate()
        {
            _exploded.Called -= OnCalled;
        }

        public void Activate()
        {
            _exploded.Called += OnCalled;
        }

        private void OnCalled()
        {
            Object.Destroy(_gameObject);
        }
    }
}