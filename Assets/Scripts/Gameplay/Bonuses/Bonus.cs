using System;
using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.Bonuses
{
    public abstract class Bonus : MonoBehaviour, IBonus
    {
        [SerializeField]
        private float _speed;
        
        private void Update()
        {
            Move(_speed);
        }

        public virtual void ApplyBonus(PlayerSpaceship playerSpaceship)
        {
            
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var playerSpaceship = other.gameObject.GetComponent<PlayerSpaceship>();

            if (playerSpaceship != null)
            {
                ApplyBonus(playerSpaceship);
                Destroy(gameObject);
            }
        }
        
        
        private  void Move(float speed)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.down);
        }
    }
}