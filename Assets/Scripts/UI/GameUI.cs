using Gameplay.MainGame;
using Gameplay.Spaceships;
using UI.Windows;
using UnityEngine;

namespace UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private PlayerStatsUI _playerStatsUI;
        [SerializeField] private PlayerWeaponUI _playerWeaponUI;
        [SerializeField] private GameOverWindow _gameOverWindow;
        private PlayerSpaceship _playerSpaceship;
        private Game _game;
        private GameBootstrapper _gameBootstrapper;

        public void Initialize(Game game, PlayerSpaceship playerSpaceship, GameBootstrapper gameBootstrapper)
        {
            _gameBootstrapper = gameBootstrapper;
            _game = game;
            _playerSpaceship = playerSpaceship;
        
            _playerSpaceship.HealthSystem.HealthChanged += OnPlayerHealthChanged;
            _playerSpaceship.HealthSystem.OnDeath += OnDeath;
            _playerSpaceship.WeaponSystem.OnWeaponRateChange += OnWeaponRateChange;
            _game.OnScoreChange += OnScoreChange;
        }

        private void OnDeath()
        {
            _gameOverWindow.Initialize(_game.Score, () =>
            {
                _gameBootstrapper.ReloadLevel();
            });
            _gameOverWindow.Show();
        }

        private void OnWeaponRateChange(float rate) => _playerWeaponUI.UpdateWeaponRateValue(rate);

        private void OnScoreChange(int score) => _playerStatsUI.UpdateScoreValue(score);

        private void OnPlayerHealthChanged(float health) => _playerStatsUI.UpdateHealthValue(health);
        
    }
}
