using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ClickRaycast : MonoBehaviour
    {
        public event Action<RaycastHit> Raycast;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hit))
                {
                    Raycast?.Invoke(hit);
                }
            }
        }
    }
}