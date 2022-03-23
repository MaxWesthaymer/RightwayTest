using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerStatsUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthValue;
        [SerializeField] private TextMeshProUGUI _scoreValue;

        public void UpdateScoreValue(int score)
        {
            _scoreValue.text = score.ToString();
        }
    
        public void UpdateHealthValue(float health)
        {
            _healthValue.text = health.ToString("00");
        }
    }
}
