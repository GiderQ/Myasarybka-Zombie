using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab,skeletonPrefab;
    public Transform player;
    public float spawnRate = 2f;  
    public float spawnDistance = 10f; 

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnZombie();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnZombie()
    {
        if (player == null) return;

        Vector2 spawnDir = Random.insideUnitCircle.normalized;
        Vector3 spawnPos = player.position + (Vector3)(spawnDir * spawnDistance);
        if (Random.Range(1,3) == 3)
        {
            Instantiate(skeletonPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
        }

    }
}
