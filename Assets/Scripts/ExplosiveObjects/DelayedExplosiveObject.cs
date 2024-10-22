using System.Collections.Generic;
using HealthMechanics;
using Service;
using UnityEngine;

namespace ExplosiveObjects
{
    public class DelayedExplosiveObject : MonoBehaviour
    {
        [SerializeField] private HealthReactTrigger _trigger;
        [SerializeField] private int _damage;
        [SerializeField] private float _explosionDelay;
        [SerializeField] private ParticleSystem _effectPrefab;
        
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

            yield return new DestroyTimerController(_trigger, _exploded, _explosionDelay);
            yield return new ReduceHealthController(_exploded, triggerCollider, _damage);
            yield return new DestroyExplosiveObjectController(_exploded, gameObject);
            yield return new ExplosionEffectController(_exploded, _effectPrefab, transform);
        }
    }
}