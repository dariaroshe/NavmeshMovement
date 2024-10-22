using System;

namespace Service
{
    public class EventField
    {
        public event Action Called;

        public void Call()
        {
            Called?.Invoke();
        }
    }
    
    public class EventField<T>
    {
        public event Action<T> Called;

        public void Call(T value)
        {
            Called?.Invoke(value);
        }
    }
}