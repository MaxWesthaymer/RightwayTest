using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class GameOverWindow : Window
    {
        [SerializeField] private Button _tryAgain;
        [SerializeField] private TextMeshProUGUI _finalScore;

        public void Initialize(int score, Action buttonAction)
        {
            _finalScore.text = $"YOUR SCORE  {score}";
            _tryAgain.onClick.AddListener(buttonAction.Invoke);
        }
        
    }
}
