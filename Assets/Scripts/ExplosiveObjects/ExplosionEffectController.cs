using Service;
using UnityEngine;

namespace ExplosiveObjects
{
    public class ExplosionEffectController : IController
    {
        private readonly EventField _exploded;
        private readonly ParticleSystem _effectPrefab;
        private readonly Transform _transform;

        public ExplosionEffectController(EventField exploded, ParticleSystem effectPrefab, Transform transform)
        {
            _exploded = exploded;
            _effectPrefab = effectPrefab;
            _transform = transform;
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
            var effect = Object.Instantiate(_effectPrefab, _transform.position, Quaternion.identity);
            effect.Play();
        }
    }
}