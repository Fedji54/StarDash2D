using Lean.Pool;
using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class RoomSpawner : Singleton<RoomSpawner>
    {
        [SerializeField] private float _roomSpeed = 5f;
        [SerializeField] private Transform _startRoomPoint;
        [SerializeField] private bool _testRoom = false;
        [SerializeField] private int _testRoomIndex;
        [SerializeField] private List<GameObject> _rooms = new();

        private Room _lastRoom;

        private Room GetRandomRoom() => _testRoom ? _rooms[_testRoomIndex].GetComponent<Room>() : _rooms[Random.Range(0, _rooms.Count)].GetComponent<Room>();

        public float RoomSpeed => _roomSpeed;
        public Transform StartRoomPoint => _startRoomPoint;

        public void SpawnStartRoom()
        {
            ClearRooms();
            Room room = GetRandomRoom();
            _lastRoom = LeanPool.Spawn(room, _startRoomPoint.position, Quaternion.identity);
        }

        public void Spawn()
        {
            Room room = GetRandomRoom();
            _lastRoom = LeanPool.Spawn(room, _lastRoom.transform.position + Vector3.up * _lastRoom.RoomSize.y, Quaternion.identity);
        }

        public void ClearRooms()
        {
            Room[] rooms = FindObjectsOfType<Room>();
            foreach (Room room in rooms)
            {
                LeanPool.Despawn(room.gameObject);
            }
        }
    }
}