using System.Collections;
using Gameplay.MainGame;
using Gameplay.Spaceships;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Spawners
{
    public class Spawner : MonoBehaviour
    {

        [SerializeField]
        private GameObject _object;
        
        [SerializeField]
        private Transform _parent;
        
        [SerializeField]
        private Vector2 _spawnPeriodRange;
        
        [SerializeField]
        private Vector2 _spawnDelayRange;

        [SerializeField]
        private bool _autoStart = true;

        private Game _game;

        public void Initialize(Game game)
        {
            _game = game;

            if (_autoStart)
                StartSpawn();
        }


        private void StartSpawn()
        {
            StartCoroutine(Spawn());
        }

        public void StopSpawn()
        {
            StopAllCoroutines();
        }


        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(Random.Range(_spawnDelayRange.x, _spawnDelayRange.y));
            
            while (true)
            {
                var ship = Instantiate(_object, transform.position, transform.rotation, _parent).GetComponent<Spaceship>();
                ship.Initialize(_game);
                
                yield return new WaitForSeconds(Random.Range(_spawnPeriodRange.x, _spawnPeriodRange.y));
            }
        }
    }
}
