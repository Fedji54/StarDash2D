using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class PatrolBehaviour : ObstacleBehaviour
    {
        [SerializeField] private float _minSpeed = 4f;
        [SerializeField] private float _maxSpeed = 8f;
        [SerializeField] private Transform[] points;

        private List<Vector3> _localPositions = new();
        private bool _reverse;
        private float _moveSpeed;
        private int _curIndex;

        private void Start()
        {
            foreach (Transform t in points)
            {
                _localPositions.Add(t.localPosition + _affectedObject.localPosition);
            }
        }

        private void OnEnable()
        {
            _moveSpeed = Random.Range(_minSpeed, _maxSpeed);
            _reverse = Random.value > 0.5f;
            _curIndex = _reverse ? points.Length - 1 : 0;
        }

        private void Update()
        {
            if(GameManager.StaticInstance.Paused)
            {
                return;
            }
            if (_affectedObject.localPosition != _localPositions[_curIndex])
            {
                _affectedObject.localPosition = Vector3.MoveTowards(_affectedObject.localPosition, _localPositions[_curIndex], _moveSpeed * Time.deltaTime);
            }
            else if (_reverse)
            {
                if (_curIndex > 0)
                {
                    _curIndex--;
                }
                else
                {
                    _curIndex = _localPositions.Count - 1;
                }
            }
            else
            {
                if (_curIndex < _localPositions.Count - 1)
                {
                    _curIndex++;
                }
                else
                {
                    _curIndex = 0;
                }
            }
        }
    }
}