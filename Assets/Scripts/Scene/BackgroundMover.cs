using UnityEngine;

namespace Scene
{
    public class BackgroundMover : MonoBehaviour
    {
        [SerializeField] private Renderer _backgroundRenderer;
        [SerializeField] private float _speed;
        private Vector2 _backgroundTextureOffset;

        private void Awake()
        {
            _backgroundTextureOffset = _backgroundRenderer.material.mainTextureOffset;
        }

        private void Update()
        {
            if (_backgroundTextureOffset.y >= 1)
                _backgroundTextureOffset = Vector2.zero;

            _backgroundTextureOffset += Vector2.up * _speed * Time.deltaTime;
            _backgroundRenderer.material.mainTextureOffset = _backgroundTextureOffset;
        }
    }
}