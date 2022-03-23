using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class EnemySnakeShipController : EnemyShipController
    {
        [SerializeField]private float _changeDirectionCooldown = 0.5f;
        private int _lateralDirection;
        private float _cooldown;

        public override void Init(ISpaceship spaceship)
        {
            base.Init(spaceship);
            _lateralDirection = 1;
            _cooldown = _changeDirectionCooldown;
        }

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            movementSystem.LongitudinalMovement(Time.deltaTime);
            SnakeMovement(movementSystem);
        }

        private void SnakeMovement(MovementSystem movementSystem)
        {
            if (_cooldown <= 0)
            {
                _cooldown = _changeDirectionCooldown;
                _lateralDirection *= -1;
            }
            movementSystem.LateralMovement(Time.deltaTime * _lateralDirection);
            _cooldown -= Time.deltaTime;
        }
    }
}