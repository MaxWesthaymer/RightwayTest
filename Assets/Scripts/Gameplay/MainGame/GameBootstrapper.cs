using Gameplay.Spaceships;
using Gameplay.Spawners;
using UI;
using UnityEngine;

namespace Gameplay.MainGame
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private Spawner[] _spawners;
        [SerializeField] private PlayerSpaceship _playerShip;
        [SerializeField] private PlayerStatsUI _playerStatsUI;
        [SerializeField] private PlayerWeaponUI _playerWeaponUI;
        private Game _game;

        private void Awake()
        {
            _game = new Game();
        }

        private void Start()
        {
            InitializeGameElements();
        }

        private void InitializeGameElements()
        {
            foreach (Spawner spawner in _spawners)
                spawner.Initialize(_game);

            _playerShip.HealthSystem.HealthChanged += OnPlayerHealthChanged;
            _playerShip.WeaponSystem.OnWeaponRateChange += OnWeaponRateChange;
            _game.OnScoreChange += OnScoreChange;
            _playerShip.Initialize(_game);
        }

        private void OnWeaponRateChange(float rate)
        {
            _playerWeaponUI.UpdateWeaponRateValue(rate);
        }

        private void OnScoreChange(int score) => _playerStatsUI.UpdateScoreValue(score);

        private void OnPlayerHealthChanged(float health) => _playerStatsUI.UpdateHealthValue(health);

        private void OnDestroy()
        {
            _playerShip.HealthSystem.HealthChanged -= OnPlayerHealthChanged;
            _game.OnScoreChange -= OnScoreChange;
        }
    }
}
