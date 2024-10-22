using System.Collections.Generic;
using UnityEngine;

namespace Service
{
    public class UpdatableRunner : MonoBehaviour
    {
        private readonly List<IUpdatable> _updatableList = new();
        private readonly HashSet<IUpdatable> _needRemove = new();

        private void Update()
        {
            foreach (var updatable in _needRemove)
            {
                _updatableList.Remove(updatable);
            }

            foreach (var updatable in _updatableList)
            {
                if (!_needRemove.Contains(updatable))
                {
                    updatable.Update();
                }
            }
            
            _needRemove.Clear();
        }

        public void Remove(IUpdatable updatable)
        {
            _needRemove.Add(updatable);
        }

        public void Add(IUpdatable updatable)
        {
            _updatableList.Add(updatable);
        }
    }
}