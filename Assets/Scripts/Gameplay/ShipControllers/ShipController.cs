﻿using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.ShipControllers
{
    public abstract class ShipController : MonoBehaviour
    {

        private ISpaceship _spaceship;


        public virtual void Init(ISpaceship spaceship)
        {
            _spaceship = spaceship;
        }


        private void Update()
        {
            if(_spaceship == null)
                return;
            
            ProcessHandling(_spaceship.MovementSystem);
            ProcessFire(_spaceship.WeaponSystem);
        }


        protected abstract void ProcessHandling(MovementSystem movementSystem);
        protected abstract void ProcessFire(WeaponSystem fireSystem);
    }
}
