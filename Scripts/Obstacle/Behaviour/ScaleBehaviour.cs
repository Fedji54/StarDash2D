using UnityEngine;

namespace WinterUniverse
{
    public class ScaleBehaviour : ObstacleBehaviour
    {
        [SerializeField] private float _minSpeed = 2f;
        [SerializeField] private float _maxSpeed = 4f;
        [SerializeField] private Vector3 _minSize = new(1f, 1f, 1f);
        [SerializeField] private Vector3 _maxSize = new(4f, 4f, 4f);

        private float _scaleSpeed;
        private bool _reverse;

        private void OnEnable()
        {
            _scaleSpeed = Random.Range(_minSpeed, _maxSpeed);
        }

        private void Update()
        {
            if (GameManager.StaticInstance.Paused)
            {
                return;
            }
            if (_reverse)
            {
                _affectedObject.localScale = Vector3.MoveTowards(_affectedObject.localScale, _minSize, _scaleSpeed * Time.deltaTime);
                if (_affectedObject.localScale == _minSize)
                {
                    _reverse = false;
                }
            }
            else
            {
                _affectedObject.localScale = Vector3.MoveTowards(_affectedObject.localScale, _maxSize, _scaleSpeed * Time.deltaTime);
                if (_affectedObject.localScale == _maxSize)
                {
                    _reverse = true;
                }
            }
        }
    }
}