using System;
using Game;
using Service;
using UnityEngine;

namespace Start
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private GameView _view;
        
        private IController _controller;

        private void OnDestroy()
        {
            _controller.Deactivate();
        }

        private void Start()
        {
            var model = new GameModel();
            
            _controller = new GameStartController(model, _view);
            _controller.Activate();
        }
    }
}