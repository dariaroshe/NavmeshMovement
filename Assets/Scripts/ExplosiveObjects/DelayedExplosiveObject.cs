using System.Collections.Generic;
using HealthMechanics;
using Service;
using UnityEngine;

namespace ExplosiveObjects
{
    public class DelayedExplosiveObject : MonoBehaviour
    {
        [SerializeField] private HealthReactTrigger _trigger;
        private readonly EventField _exploded = new();

        private readonly List<IController> _controllers = new();

        private void OnDestroy()
        {
            foreach (var controller in _controllers)
            {
                controller.Deactivate();
            }
        }

        private void Start()
        {
            _controllers.AddRange(CreateControllers());

            foreach (var controller in _controllers)
            {
                controller.Activate();
            }
        }

        private IEnumerable<IController> CreateControllers()
        {
            var triggerCollider = _trigger.GetComponent<SphereCollider>();

            yield return new DestroyTimerController(_trigger, _exploded);
            yield return new ReduceHealthController(_exploded, triggerCollider);
            yield return new DestroyExplosiveObjectController(_exploded, gameObject);
        }
    }
}