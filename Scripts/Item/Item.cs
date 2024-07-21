using Lean.Pool;
using UnityEngine;

namespace WinterUniverse
{
    public abstract class Item : MonoBehaviour
    {
        protected abstract void OnUse();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player) && player.Alive)
            {
                SoundManager.StaticInstance.PlaySound(SoundType.PickUp);
                OnUse();
                LeanPool.Despawn(gameObject);
            }
        }
    }
}