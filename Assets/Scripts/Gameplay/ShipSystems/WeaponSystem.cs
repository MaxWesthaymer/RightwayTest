using System;
using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;
using System.Linq;

namespace Gameplay.ShipSystems
{
    public class WeaponSystem : MonoBehaviour
    {

        public event Action<float> OnWeaponRateChange;
        [SerializeField]
        private List<Weapon> _weapons;



        public void Init(UnitBattleIdentity battleIdentity)
        {
            _weapons.ForEach(w => w.Init(battleIdentity));
            OnWeaponRateChange?.Invoke(GetWeaponsRate());
        }
        
        
        public void TriggerFire()
        {
            _weapons.ForEach(w => w.TriggerFire());
        }

        public void RateUpWeapons(int rateUpValue)
        {
            _weapons.ForEach(w => w.RateUp(rateUpValue));
            OnWeaponRateChange?.Invoke(GetWeaponsRate());
        }

        private float GetWeaponsRate()
        {
            float rate = 0;

            foreach (var weapon in _weapons)
                rate += weapon.GetWeaponRate();

            return rate;
        }

    }
}
