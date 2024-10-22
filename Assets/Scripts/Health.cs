using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action Increased; 
    public event Action Reduced; 
        
    public int Value { get; private set; }
    [field: SerializeField] public int MaxValue { get; private set; }

    public bool IsAlive => Value > 0;

    private void Awake()
    {
        Value = MaxValue;
    }

    public void Reduce(int damage)
    {
        Value -= damage;

        if (Value < 0)
        {
            Value = 0;
        }
            
        Reduced?.Invoke();
        Debug.Log(Value);
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