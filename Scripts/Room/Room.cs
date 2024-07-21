using Lean.Pool;
using UnityEngine;

namespace WinterUniverse
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private Vector2 _roomSize;

        public Vector2 RoomSize => _roomSize;
        private bool _nextRoomSpawned;

        private void OnEnable()
        {
            _nextRoomSpawned = false;
        }

        private void Update()
        {
            if (GameManager.StaticInstance.Paused)
            {
                return;
            }
            transform.Translate(Vector3.down * RoomSpawner.StaticInstance.RoomSpeed * Time.deltaTime);
            if (!_nextRoomSpawned && transform.position.y + _roomSize.y <= RoomSpawner.StaticInstance.StartRoomPoint.position.y)
            {
                _nextRoomSpawned = true;
                RoomSpawner.StaticInstance.Spawn();
            }
            else if (transform.position.y <= -_roomSize.y)
            {
                LeanPool.Despawn(gameObject);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position + Vector3.up * _roomSize.y / 2f, _roomSize);
        }
    }
}