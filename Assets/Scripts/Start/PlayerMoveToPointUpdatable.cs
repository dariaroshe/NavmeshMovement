using Game;
using Service;
using UnityEngine;

namespace Start
{
    public class PlayerMoveToPointUpdatable : IUpdatable
    {
        private readonly GameModel _model;
        private readonly Camera _camera;

        public PlayerMoveToPointUpdatable(GameModel model, Camera camera)
        {
            _model = model;
            _camera = camera;
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hit))
                {
                    _model.MovePlayer.Call(hit.point);
                }
            }
        }
    }
}