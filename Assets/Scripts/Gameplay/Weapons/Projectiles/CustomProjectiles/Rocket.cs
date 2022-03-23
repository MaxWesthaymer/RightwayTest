using UnityEngine;

namespace Gameplay.Weapons.Projectiles.CustomProjectiles
{
    public class Rocket : Projectile
    {
        [SerializeField] private float _lifetime;
        [SerializeField] private float _damageRadius = 3f;
        [SerializeField] private GameObject _explosionView;

        private float _cooldown;

        public override void Init(UnitBattleIdentity battleIdentity)
        {
            base.Init(battleIdentity);
            _cooldown = _lifetime;
        }

        protected override void Update()
        {
            if (_cooldown <= 0)
            {
                Explosion();
                return;
            }
            base.Update();
            
            _cooldown -= Time.deltaTime;
        }

        protected override void OnCollisionEnter2D(Collision2D other)
        {
            var damagableObject = other.gameObject.GetComponent<IDamagable>();
            
            if (damagableObject != null 
                && damagableObject.BattleIdentity != BattleIdentity)
            {
                Explosion();
            }
        }

        private void Explosion()
        {
            SetDamage();
            
            _explosionView.SetActive(true);
            Destroy(gameObject, 0.1f);
        }

        private void SetDamage()
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _damageRadius);

            foreach (Collider2D collider in hitColliders)
            {
                var damagableObject = collider.gameObject.GetComponent<IDamagable>();

                if (damagableObject != null)
                {
                    damagableObject.ApplyDamage(this);
                }
            }
        }
    }
}