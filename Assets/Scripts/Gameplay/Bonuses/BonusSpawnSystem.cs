using UnityEngine;

namespace Gameplay.Bonuses
{
    public class BonusSpawnSystem : MonoBehaviour
    {
        [SerializeField] private Bonus[] _bonuses;
        [SerializeField] private float _spawnChance = 0.3f;


        public void TrySpawnBonus()
        {
            float randomValue = Random.value;
            
            if (randomValue < _spawnChance)
            {
                Instantiate(_bonuses[Random.Range(0, _bonuses.Length)], transform.position, Quaternion.identity);
            }
        }
    }
    
}