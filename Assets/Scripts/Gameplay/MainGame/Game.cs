using System;

namespace Gameplay.MainGame
{
    public class Game
    {
        public event Action<int> OnScoreChange;
        public int Score => _score;
        private int _score;

        public Game()
        {
            _score = 0;
            OnScoreChange?.Invoke(_score);
        }

        public void AddScore()
        {
            _score++;
            OnScoreChange?.Invoke(_score);
        }
    }
}