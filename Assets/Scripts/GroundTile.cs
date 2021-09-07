using UnityEngine;
using Random = UnityEngine.Random;


public class GroundTile : MonoBehaviour
{
    private GroundSpawner _groundSpawner;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerExit(Collider other)
    {
        _groundSpawner.SpawnTile(true);
        Destroy(gameObject, 5);
    }

    public void SpawnObstacle()
    {
        if (Random.Range(0, 3) == 0) // Randomly spawn or don't spawn an obstacle
        {
            // choose a random point to spawn the obsctacle
            int obstacleSpawnIndex = Random.Range(2, 5);
            Vector3 spawnPoint = transform.GetChild(obstacleSpawnIndex).transform.position;
            spawnPoint.y = 3;
            Instantiate(obstaclePrefab, spawnPoint, Quaternion.identity, transform);
        }
    }

    public void SpawnCoins()
    {
        if (Random.Range(0, 3) == 0) // Randomly spawn or don't spawn coins
        {
            int coinsToSpawn = Random.Range(5, 10);
            Collider collider = GetComponent<Collider>();
            float pointX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
            float pointZ = Random.Range(collider.bounds.min.z, collider.bounds.max.z);
            float pointY = 3;

            for (int i = 0; i < coinsToSpawn; i++)
            {
                GameObject temp = Instantiate(coinPrefab, transform);
                temp.transform.position = new Vector3(pointX, pointY, pointZ);
                pointZ++;
            }
        }
    }


    public void SpawnEnemy()
    {
        if (Random.Range(0, 6) == 0) // Randomly spawn or don't spawn enemy
        {
            Collider collider = GetComponent<Collider>();
            float pointX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
            float pointZ = Random.Range(collider.bounds.min.z, collider.bounds.max.z);
            float pointY = 3;


            GameObject temp = Instantiate(enemyPrefab, transform);
            temp.transform.position = new Vector3(pointX, pointY, pointZ);
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 randomPoint = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));

        if (randomPoint != collider.ClosestPoint(randomPoint))
        {
            randomPoint = GetRandomPointInCollider(collider);
        }

        randomPoint.y = 2;
        return randomPoint;
    }
}