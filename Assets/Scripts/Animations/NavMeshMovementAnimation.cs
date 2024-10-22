using System;
using UnityEngine;
using UnityEngine.AI;

namespace Animations
{
    public class NavMeshMovementAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _agent;
        
        private static readonly int Movement = Animator.StringToHash("Movement");
        private const float DampTime = 0.1f;
        private const float IdleValue = 0f;
        private const float RunValue = 1f;


        private void Update()
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                _animator.SetFloat(Movement, IdleValue, DampTime, Time.deltaTime);
            }
            else
            {
                _animator.SetFloat(Movement, RunValue, DampTime, Time.deltaTime);
            }
            
        }
    }
}