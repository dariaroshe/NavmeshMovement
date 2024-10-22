using HealthMechanics;
using Service;
using UnityEngine;

namespace ExplosiveObjects
{
    public class ReduceHealthController : IController
    {
        private readonly SphereCollider _collider;
        private readonly EventField _exploded;
        private int _damageMine = 10;

        public ReduceHealthController(EventField exploded, SphereCollider collider)
        {
            _exploded = exploded;
            _collider = collider;
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
            var allColliders = Physics.OverlapSphere(_collider.transform.position, _collider.radius);

            foreach (var impactedCollider in allColliders)
            {
                if (impactedCollider.TryGetComponent(out Health health))
                {
                    health.Reduce(_damageMine);
                }
            }
        }
    }
}