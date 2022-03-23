using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.Bonuses
{
    public class HealthBonus : Bonus
    {
        [SerializeField] private int _healthValue = 50;
        public override void ApplyBonus(PlayerSpaceship playerSpaceship)
        {
            playerSpaceship.HealthSystem.GiveHealth(_healthValue);
        }
    }
}