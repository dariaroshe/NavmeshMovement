using System;
using HealthMechanics;
using UnityEngine;

namespace Animations
{
    public class GetDamageAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Health _health;
        
        private static readonly int GetDamage = Animator.StringToHash("GetDamage");
        private static readonly int Die = Animator.StringToHash("Die");

        private void OnDestroy()
        {
            _health.Reduced -= OnReduced;
        }

        private void Start()
        {
            _health.Reduced += OnReduced;
        }

        private void OnReduced()
        {
            if (_health.IsAlive)
            {
                _animator.SetTrigger(GetDamage);
            }
            else
            {
                _animator.SetTrigger(Die);
            }
        }
    }
}