using UnityEngine;

namespace WinterUniverse
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private float _damage = 5f;

        public float Damage => _damage;
    }
}