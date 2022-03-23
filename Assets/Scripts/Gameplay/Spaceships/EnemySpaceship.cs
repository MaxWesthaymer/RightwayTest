using Gameplay.Bonuses;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships

{
    public class EnemySpaceship : Spaceship
    {
        [SerializeField] private BonusSpawnSystem _bonusSpawnSystem;


        public override void ApplyDamage(IDamageDealer damageDealer)
        {
            if (damageDealer.BattleIdentity == UnitBattleIdentity.Ally)
                _game.AddScore();
            
            _bonusSpawnSystem.TrySpawnBonus();
            Destroy(gameObject);
        }
    }
}