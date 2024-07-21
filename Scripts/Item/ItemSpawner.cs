using Lean.Pool;
using UnityEngine;

namespace WinterUniverse
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField, Range(0f, 1f)] private float _chance = 0.25f;
        [SerializeField] private GameObject[] _items;

        private GameObject _spawned;

        private void OnEnable()
        {
            if (_spawned != null && _spawned.activeInHierarchy)
            {
                LeanPool.Despawn(_spawned);
            }
            if (_chance >= Random.value)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            _spawned = LeanPool.Spawn(_items[Random.Range(0, _items.Length)], transform);
        }
    }
}