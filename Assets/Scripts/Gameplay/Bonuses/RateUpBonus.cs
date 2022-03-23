using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.Bonuses
{
    public class RateUpBonus : Bonus
    {
        [SerializeField] private int _rateUpValue = 100;
        public override void ApplyBonus(PlayerSpaceship playerSpaceship)
        {
            playerSpaceship.WeaponSystem.RateUpWeapons(_rateUpValue);
        }
    }
}