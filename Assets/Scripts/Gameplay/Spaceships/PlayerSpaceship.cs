﻿using Gameplay.MainGame;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class PlayerSpaceship: Spaceship
    {
        [SerializeField]
        private  HealthSystem healthSystem;

        public HealthSystem HealthSystem => healthSystem;

        public override void Initialize(Game game)
        {
            base.Initialize(game);
            healthSystem.Init();
        }

        public override void ApplyDamage(IDamageDealer damageDealer)
        {
            if (damageDealer.BattleIdentity != BattleIdentity)
            {
                healthSystem.TakeDamage(damageDealer.Damage);
            }
        }
    }
}