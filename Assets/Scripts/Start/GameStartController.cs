using System.Collections.Generic;
using Game;
using Marker;
using Service;

namespace Start
{
    public class GameStartController : IController
    {
        private readonly GameModel _model;
        private readonly GameView _view;
        
        private readonly List<IController> _controllers = new();
        private readonly List<IUpdatable> _updatableList = new();

        public GameStartController(GameModel model, GameView view)
        {
            _model = model;
            _view = view;
        }
        
        public void Deactivate()
        {
            foreach (var controller in _controllers)
            {
                controller.Deactivate();
            }

            foreach (var updatable in _updatableList)
            {
                _view.UpdatableRunner.Remove(updatable);
            }
            
            _updatableList.Clear();
            _controllers.Clear();
        }

        public void Activate()
        {
            _updatableList.Add(new PlayerMoveToPointUpdatable(_model, _view.Camera));
            
            _controllers.Add(new MarkerController(_model, _view.Marker));
            
            foreach (var controller in _controllers)
            {
                controller.Activate();
            }

            foreach (var updatable in _updatableList)
            {
                _view.UpdatableRunner.Add(updatable);
            }
        }
    }
}