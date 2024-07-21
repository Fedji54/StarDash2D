using UnityEngine;

namespace WinterUniverse
{
    public class PlayerInput : Singleton<PlayerInput>
    {
        [SerializeField] private Camera _cam;

        private Vector2 _movePosition;
        private Touch _touch;

        public Vector3 MovePosition => _movePosition;

        private void Start()
        {
            _movePosition = _cam.transform.position;
        }

        private void Update()
        {
            if (GameManager.StaticInstance.Paused)
            {
                _movePosition = Player.StaticInstance.transform.position;
                return;
            }
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);
                _movePosition = _cam.ScreenToWorldPoint(_touch.position);
            }
            else if (Input.GetMouseButton(0))
            {
                _movePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }
}