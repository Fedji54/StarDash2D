using UnityEngine;

namespace WinterUniverse
{
    public class Trap : Item
    {
        [SerializeField] private float _damage = 5f;

        protected override void OnUse()
        {
            Player.StaticInstance.TakeDamage(_damage);
        }
    }
}