using Service;
using UnityEngine.UI;

namespace HealthMechanics
{
    internal class HealthBarController : IController
    {
        private readonly Health _health;
        private readonly Image _bar;

        public HealthBarController(Health health, Image bar)
        {
            _health = health;
            _bar = bar;
        }

        public void Deactivate()
        {
            _health.Reduced -= OnReduced;
            _health.Increased -= OnIncreased;
        }

        public void Activate()
        {
            UpdateBar();
            
            _health.Reduced += OnReduced;
            _health.Increased += OnIncreased;
        }

        private void OnIncreased()
        {
            UpdateBar();
        }

        private void OnReduced()
        {
            UpdateBar();
        }

        private void UpdateBar()
        {
            _bar.fillAmount = ((float)_health.Value) / _health.MaxValue;
        }
    }
}