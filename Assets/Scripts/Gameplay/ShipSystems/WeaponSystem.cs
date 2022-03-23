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
            OnWeaponRateChange?.Invoke(_weapons[0].GetWeaponRate());
        }
        
        
        public void TriggerFire()
        {
            _weapons.ForEach(w => w.TriggerFire());
        }

    }
}
