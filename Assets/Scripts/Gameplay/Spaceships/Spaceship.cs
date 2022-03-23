using System;
using Gameplay.MainGame;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public abstract class Spaceship : MonoBehaviour, ISpaceship, IDamagable
    {
        [SerializeField] private ShipController _shipController;
        [SerializeField] private MovementSystem _movementSystem;
        [SerializeField] private WeaponSystem _weaponSystem;
        [SerializeField] private UnitBattleIdentity _battleIdentity;

        protected Game _game;

        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        public virtual void Initialize(Game game)
        {
            _game = game;
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
        }

        public virtual void ApplyDamage(IDamageDealer damageDealer)
        {
            
        }
    }
}