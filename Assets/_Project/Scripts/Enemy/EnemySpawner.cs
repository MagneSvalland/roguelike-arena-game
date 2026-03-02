using UnityEngine;

namespace FirstRoguelike.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Spawner Settings")]
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int enemiesPerWave = 5;
        [SerializeField] private float spawnRadius = 8f;
        [SerializeField] private float timeBetweenWaves = 10f;

        private Transform _playerTransform;
        private float _waveTimer;

        private void Start()
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
                _playerTransform = player.transform;

            // Spawn first wave immediately
            SpawnWave();
        }

        private void Update()
        {
            _waveTimer += Time.deltaTime;
            if (_waveTimer >= timeBetweenWaves)
            {
                _waveTimer = 0f;
                SpawnWave();
            }
        }

        private void SpawnWave()
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                Vector2 spawnPos = GetRandomSpawnPosition();
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            }
        }

        private Vector2 GetRandomSpawnPosition()
        {
            Vector2 center = _playerTransform != null
                ? (Vector2)_playerTransform.position
                : Vector2.zero;

            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            return center + new Vector2(
                Mathf.Cos(angle) * spawnRadius,
                Mathf.Sin(angle) * spawnRadius
            );
        }
    }
}