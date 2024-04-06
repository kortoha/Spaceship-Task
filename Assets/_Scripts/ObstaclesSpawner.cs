using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclesArray;
    [SerializeField] private Transform[] _spawnPointsArray;

    private bool _isCanSpawning = false;
    private float _spawnTimer = 0f;
    private float _spawnDelay = 0f;

    private void Update()
    {
        if (_isCanSpawning)
        {
            _spawnTimer += Time.deltaTime;

            if (_spawnTimer >= _spawnDelay)
            {
                SpawnObstacle();
                _spawnDelay = Random.Range(0.5f, 1f); 
                _spawnTimer = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }

    public void SetIsCanSpawn(bool isCanSpawn)
    {
        _isCanSpawning = isCanSpawn;
    }

    private void SpawnObstacle()
    {
        GameObject obstacleToSpawn = GetInactiveObstacle();
        Transform spawnPoint = GetRandomSpawnPoint();

        if (obstacleToSpawn != null && spawnPoint != null)
        {
            obstacleToSpawn.SetActive(true);
            obstacleToSpawn.transform.position = spawnPoint.position;
        }
    }

    private GameObject GetInactiveObstacle()
    {
        GameObject inactiveObstacle = null;

        foreach (GameObject obstacle in _obstaclesArray)
        {
            if (!obstacle.activeSelf)
            {
                inactiveObstacle = obstacle;
                break;
            }
        }

        return inactiveObstacle;
    }

    private Transform GetRandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, _spawnPointsArray.Length);
        return _spawnPointsArray[randomIndex];
    }
}
