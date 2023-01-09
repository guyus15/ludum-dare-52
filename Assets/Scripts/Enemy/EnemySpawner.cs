using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private const int MAX_ENEMIES = 200;

    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private float _initialSpawnPeriod;
    [SerializeField] private float _initialSpawnDelay;
    private float _currentSpawnPeriod;
    private float _currentTime;

    private EnemyManager _enemyManager;

    private void Start()
    {
        // Give each spawner a random offset so they don't all spawn at the same time.
        _currentTime = (Random.value * _initialSpawnPeriod) - _initialSpawnDelay;
        _currentSpawnPeriod = _initialSpawnPeriod;

        _enemyManager = FindObjectOfType<EnemyManager>();
    }

    private void Update()
    {
        if (_currentTime >= _currentSpawnPeriod && CanSpawn())
        {
            Spawn();

            _currentTime = 0.0f;
            _currentSpawnPeriod -= 0.5f;
        }

        _currentTime += Time.deltaTime;
    }

    private bool CanSpawn()
    {
        return _enemyManager?.CurrentNumberOfEnemies < MAX_ENEMIES;
    }

    private void Spawn()
    {
        Instantiate(_enemyPrefab, transform.position, transform.rotation);
    }
}
