using System;
using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.Weapons.Projectiles
{
    public abstract class Projectile : MonoBehaviour, IDamageDealer
    {

        [SerializeField]
        private float _speed;

        [SerializeField] 
        private float _damage;


        private UnitBattleIdentity _battleIdentity;


        public UnitBattleIdentity BattleIdentity => _battleIdentity;
        public float Damage => _damage;

        

        public virtual void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }
        

        protected virtual void Update()
        {
            Move(_speed);
        }

        
        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            var damagableObject = other.gameObject.GetComponent<IDamagable>();
            
            if (damagableObject != null 
                && damagableObject.BattleIdentity != BattleIdentity)
            {
                damagableObject.ApplyDamage(this);
            }
        }

        private void Move(float speed)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.up);
        }
    }
}
