using UnityEngine;

namespace WinterUniverse
{
    public class RotateBehaviour : ObstacleBehaviour
    {
        [SerializeField] private float _minSpeed = 90f;
        [SerializeField] private float _maxSpeed = 360f;
        private float _rotateSpeed;

        private void OnEnable()
        {
            _rotateSpeed = Random.Range(_minSpeed, _maxSpeed) * (Random.value > 0.5f ? 1f : -1f);
        }

        private void Update()
        {
            if (GameManager.StaticInstance.Paused)
            {
                return;
            }
            _affectedObject.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
        }
    }
}