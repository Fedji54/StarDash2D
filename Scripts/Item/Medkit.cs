using UnityEngine;

namespace WinterUniverse
{
    public class Medkit : Item
    {
        [SerializeField] private float _restore = 5f;

        protected override void OnUse()
        {
            Player.StaticInstance.RestoreHealth(_restore);
        }
    }
}