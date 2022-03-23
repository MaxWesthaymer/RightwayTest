using Gameplay.Spaceships;
using Gameplay.Weapons;

namespace Gameplay.Bonuses
{
    public interface IBonus
    {
        void ApplyBonus(PlayerSpaceship playerSpaceship);
    }
    
}