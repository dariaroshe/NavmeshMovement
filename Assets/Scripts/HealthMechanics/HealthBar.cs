using System.Collections.Generic;
using ExplosiveObjects;
using Service;
using UnityEngine;
using UnityEngine.UI;

namespace HealthMechanics
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Image _bar;
        
        private readonly List<IController> _controllers = new();

        private void OnDestroy()
        {
            foreach (var controller in _controllers)
            {
                controller.Deactivate();
            }
        }

        private void Start()
        {
            _controllers.AddRange(CreateControllers());

            foreach (var controller in _controllers)
            {
                controller.Activate();
            }
        }

        private IEnumerable<IController> CreateControllers()
        {
            yield return new HealthBarController(_health, _bar);
        }
    }
}