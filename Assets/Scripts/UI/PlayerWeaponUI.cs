using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerWeaponUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _weaponType;
        [SerializeField] private TextMeshProUGUI _weaponRate;

        public void UpdateWeaponRateValue(float value)
        {
            _weaponRate.text = value.ToString("00");
        }
    }
}
