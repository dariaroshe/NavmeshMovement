using HealthMechanics;
using UnityEngine;

namespace Animations
{
    public class InjuredAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Health _health;

        private const float InjuredHealthPercent = 0.3f;
        
        private static readonly int IsInjured = Animator.StringToHash("IsInjured");

        private void OnDestroy()
        {
            _health.Reduced -= OnReduced;
            _health.Increased -= OnIncreased;
        }

        private void Start()
        {
            UpdateInjured();
            
            _health.Reduced += OnReduced;
            _health.Increased += OnIncreased;
        }

        private void OnReduced()
        {
            UpdateInjured();
        }
        
        private void OnIncreased()
        {
            UpdateInjured();
        }

        private void UpdateInjured()
        {
            if (_health.Percent < InjuredHealthPercent)
            {
                _animator.SetBool(IsInjured, true);
            }
            else
            {
                _animator.SetBool(IsInjured, false);
            }
        }
    }
}