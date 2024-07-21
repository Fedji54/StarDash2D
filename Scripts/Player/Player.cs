using System;
using UnityEngine;

namespace WinterUniverse
{
    public class Player : Singleton<Player>
    {
        public Action OnHealthChanged;
        public Action OnDied;

        [SerializeField] private float _healthMax = 10f;
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _fadeSpeed = 2f;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private ParticleSystem _hitEffect;
        [SerializeField] private ParticleSystem _healEffect;
        [SerializeField] private ParticleSystem _deathEffect;
        [SerializeField] private ParticleSystem _reviveEffect;

        private float _alpha;
        private float _health;
        private bool _alive;
        private float Alpha => _alive ? 1f : 0f;

        public float Health => _health;
        public float HealthMax => _healthMax;
        public float HealthPercent => Health / HealthMax;
        public bool Alive => _alive;

        private void Update()
        {
            if (_spriteRenderer.color.a != Alpha)
            {
                _alpha = Mathf.MoveTowards(_alpha, Alpha, _fadeSpeed * Time.deltaTime);
                _spriteRenderer.color = new(1f, 1f, 1f, _alpha);
            }
            if (_alive && !GameManager.StaticInstance.Paused)
            {
                transform.position = Vector3.Lerp(transform.position, PlayerInput.StaticInstance.MovePosition, _moveSpeed * Time.deltaTime);
            }
        }

        public void TakeDamage(float damage)
        {
            if (_alive && damage > 0f)
            {
                _health = Mathf.Clamp(_health - damage, 0f, _healthMax);
                SoundManager.StaticInstance.PlaySound(SoundType.Hit);
                if (_health <= 0f)
                {
                    Die();
                }
                else
                {
                    _hitEffect.Play();
                    OnHealthChanged?.Invoke();
                }
            }
        }

        public void RestoreHealth(float restore)
        {
            if (_alive && restore > 0f)
            {
                _health = Mathf.Clamp(_health + restore, 0f, _healthMax);
                _healEffect.Play();
                OnHealthChanged?.Invoke();
            }
        }

        public void Die()
        {
            if (_alive)
            {
                _deathEffect.Play();
                SoundManager.StaticInstance.PlaySound(SoundType.Death);
                _health = 0f;
                OnHealthChanged?.Invoke();
                _alive = false;
                OnDied?.Invoke();
                GameManager.StaticInstance.GameOver();
            }
        }

        public void Revive()
        {
            _alive = enabled;
            _reviveEffect.Play();
            RestoreHealth(_healthMax);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Obstacle obstacle))
            {
                TakeDamage(obstacle.Damage);
            }
        }
    }
}