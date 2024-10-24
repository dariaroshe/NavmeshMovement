using System;
using UnityEngine;

namespace HealthMechanics
{
    public class Health : MonoBehaviour
    {
        public event Action Increased; 
        public event Action Reduced; 
        
        public int Value { get; private set; }
        [field: SerializeField] public int MaxValue { get; private set; }

        public bool IsAlive => Value > 0;
        public float Percent => (float) Value / MaxValue;

        private void Awake()
        {
            Value = MaxValue;
        }

        public void Reduce(int damage)
        {
            if (Value == 0)
            {
                return;
            }
            
            Value -= damage;

            if (Value < 0)
            {
                Value = 0;
            }
            
            Reduced?.Invoke();
        }

        public void Increase(int amount)
        {
            Value += amount;

            if (Value > MaxValue)
            {
                Value = MaxValue;
            }
            
            Increased?.Invoke();
        }
    }
}