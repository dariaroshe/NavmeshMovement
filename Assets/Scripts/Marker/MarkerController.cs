using System.Collections.Generic;
using Game;
using Service;

namespace Marker
{
    public class MarkerController : IController
    {
        private readonly GameModel _model;
        private readonly MarkerView _view;
        
        private readonly List<IController> _controllers = new();

        public MarkerController(GameModel model, MarkerView view)
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
            
            _controllers.Clear();
        }

        public void Activate()
        {
            _controllers.Add(new MarkerController(_model, _view));
            
            foreach (var controller in _controllers)
            {
                controller.Activate();
            }
        }
    }
}