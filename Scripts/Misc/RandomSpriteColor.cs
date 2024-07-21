using UnityEngine;

namespace WinterUniverse
{
    public class RandomSpriteColor : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 0.5f)] private float _min = 0.2f;
        [SerializeField, Range(0.5f, 1f)] private float _max = 0.8f;

        private SpriteRenderer _spriteRenderer;

        private float RandomFloat => Random.Range(_min, _max);

        private void OnEnable()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.color = new(RandomFloat, RandomFloat, RandomFloat);
        }
    }
}