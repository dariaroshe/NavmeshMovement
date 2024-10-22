using System;
using UnityEngine;

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
        
    }
}