using Gameplay.Helpers;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Gameplay.ShipSystems
{
    public class PlayerMovementSystem : MovementSystem
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private float _shipHalfSizeX;

        public void Start()
        {
            _shipHalfSizeX = _spriteRenderer.bounds.size.x / 2;
        }
        protected override void Move(float amount, Vector3 axis)
        {
            Vector3 axisNormalized = amount * axis.normalized;
            Vector3 newPosition = transform.position + axisNormalized;

            if (newPosition.x + _shipHalfSizeX > GameAreaHelper.RightBound)
            {
                newPosition.x = GameAreaHelper.RightBound - _shipHalfSizeX;
                transform.position = newPosition;
                return;
            }
            if (newPosition.x - _shipHalfSizeX < GameAreaHelper.LeftBound)
            {
                newPosition.x = GameAreaHelper.LeftBound + _shipHalfSizeX;
                transform.position = newPosition;
                return;
            }
            transform.Translate(axisNormalized);
        }
    }
}