using System.Collections;
using HealthMechanics;
using Service;
using UnityEngine;

namespace ExplosiveObjects
{
    public class DestroyTimerController : IController
    {
        private readonly HealthReactTrigger _trigger;
        private readonly EventField _exploded;
        
        private bool _startExplosion;
        private float _explosionDelay = 5f;
        private Coroutine _coroutine;

        public DestroyTimerController(HealthReactTrigger trigger, EventField exploded)
        {
            _trigger = trigger;
            _exploded = exploded;
        }

        public void Deactivate()
        {
            _trigger.Enter -= OnEnter;
            CoroutineManager.Stop(_coroutine);
        }

        public void Activate()
        {
            _trigger.Enter += OnEnter;
        }

        private void OnEnter(Health obj)
        {
            if (_startExplosion)
            {
                return;
            }
            
            _startExplosion = true;

            _coroutine = CoroutineManager.Run(WaitAndExplode());
        }

        private IEnumerator WaitAndExplode()
        {
            yield return new WaitForSeconds(_explosionDelay);
            
            _exploded.Call();
        }
    }
}