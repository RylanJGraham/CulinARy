using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] prefabs; // Array of prefabs to spawn
    public float spawnInterval = 2f; // Time in seconds between spawns
    public Vector3 spawnAreaSize = new Vector3(10f, 10f, 10f); // Size of the area within which to spawn prefabs

    private float timer;

    void Start()
    {
        timer = spawnInterval; // Initialize the timer with the spawn interval
    }

    void Update()
    {
        timer -= Time.deltaTime; // Decrease the timer by the elapsed time since the last frame

        if (timer <= 0f)
        {
            SpawnRandomPrefab(); // Spawn a random prefab
            timer = spawnInterval; // Reset the timer
        }
    }

    void SpawnRandomPrefab()
    {
        if (prefabs.Length == 0)
        {
            Debug.LogWarning("No prefabs assigned to the spawner.");
            return;
        }

        // Pick a random prefab from the array
        int randomIndex = Random.Range(0, prefabs.Length);
        GameObject prefabToSpawn = prefabs[randomIndex];

        // Determine a random position within the spawn area
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        // Instantiate the prefab at the random position
        Instantiate(prefabToSpawn, transform.position + randomPosition, Quaternion.identity);
    }
}
