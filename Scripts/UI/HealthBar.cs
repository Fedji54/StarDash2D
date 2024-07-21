using UnityEngine;
using UnityEngine.UI;

namespace WinterUniverse
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthImage;
        [SerializeField] private Gradient _gradient;
        [SerializeField] private Player _player;

        private void OnEnable()
        {
            _player.OnHealthChanged += UpdateUI;
            UpdateUI();
        }

        private void OnDisable()
        {
            _player.OnHealthChanged -= UpdateUI;
        }

        private void UpdateUI()
        {
            _healthImage.fillAmount = _player.HealthPercent;
            _healthImage.color = _gradient.Evaluate(_player.HealthPercent);
        }
    }
}