using System;
using UnityEngine;

namespace UI.Windows
{
    public abstract class Window : MonoBehaviour, IWindow
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        private void Awake()
        {
            ChangeCanvasAlpha(0);
        }

        public void Show()
        {
            ChangeCanvasAlpha(1);
        }

        public void Hide()
        {
            ChangeCanvasAlpha(0);
        }

        private void ChangeCanvasAlpha(float value) => _canvasGroup.alpha = value;
    }
}