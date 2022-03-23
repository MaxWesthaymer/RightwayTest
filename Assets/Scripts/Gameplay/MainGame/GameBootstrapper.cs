using Gameplay.Spaceships;
using Gameplay.Spawners;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay.MainGame
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private Spawner[] _spawners;
        [SerializeField] private PlayerSpaceship _playerShip;
        [SerializeField] private GameUI _gameUI;
        private Game _game;

        private void Awake()
        {
            _game = new Game();
        }

        private void Start()
        {
            InitializeGameElements();
        }

        public void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void InitializeGameElements()
        {
            _gameUI.Initialize(_game, _playerShip, this);
            
            foreach (Spawner spawner in _spawners)
                spawner.Initialize(_game);
            
            _playerShip.Initialize(_game);
        }
        
    }
}
