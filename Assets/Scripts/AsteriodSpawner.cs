using UnityEngine;

public class AsteriodSpawner : MonoBehaviour
{
    [Header("Asteroid Settings")]
    public GameObject asteroidPrefab;
    public int asteroidCount = 8;

    [Header("Spawn Settings")]
    public float spawnPadding = 1f;
    public float minDistanceFromPlayer = 4f;
    public int maxAttemptsPerAsteroid = 100;

    private void Start()
    {
        SpawnAsteroids();
    }

    public void SpawnAsteroids()
    {
        if (asteroidPrefab == null)
        {
            Debug.LogError("Asteroid Spawner: Assign an asteroid prefab!");
            return;
        }

        Camera cam = Camera.main;

        if (cam == null)
        {
            Debug.LogError("Asteroid Spawner: No Main Camera found!");
            return;
        }

        // Find the visible play area at the asteroid's Z position.
        float distance = Mathf.Abs(cam.transform.position.z);

        Vector3 bottomLeft = cam.ViewportToWorldPoint(
            new Vector3(0f, 0f, distance));

        Vector3 topRight = cam.ViewportToWorldPoint(
            new Vector3(1f, 1f, distance));

        float minX = bottomLeft.x + spawnPadding;
        float maxX = topRight.x - spawnPadding;
        float minY = bottomLeft.y + spawnPadding;
        float maxY = topRight.y - spawnPadding;

        if (minX >= maxX || minY >= maxY)
        {
            Debug.LogError("Asteroid Spawner: Spawn area is too small.");
            return;
        }

        // Find the player position if the GameManager has registered it.
        Vector3 playerPosition = Vector3.zero;
        bool hasPlayer = false;

        if (GameManager.instance != null &&
            GameManager.instance.playerController != null &&
            GameManager.instance.playerController.pawn != null)
        {
            playerPosition = GameManager.instance
                .playerController.pawn.transform.position;

            hasPlayer = true;
        }

        int spawned = 0;

        for (int i = 0; i < asteroidCount; i++)
        {
            bool foundPosition = false;
            Vector3 spawnPosition = Vector3.zero;

            for (int attempt = 0;
                 attempt < maxAttemptsPerAsteroid;
                 attempt++)
            {
                spawnPosition = new Vector3(
                    Random.Range(minX, maxX),
                    Random.Range(minY, maxY),
                    0f);

                if (!hasPlayer ||
                    Vector2.Distance(spawnPosition, playerPosition)
                    >= minDistanceFromPlayer)
                {
                    foundPosition = true;
                    break;
                }
            }

            if (!foundPosition)
            {
                Debug.LogWarning(
                    "Could not find a safe position for asteroid " + i);
                continue;
            }

            GameObject spawnedAsteroid = Instantiate(
     asteroidPrefab,
     spawnPosition,
     Quaternion.identity
 );

            astriod asteroidScript = spawnedAsteroid.GetComponent<astriod>();

            if (asteroidScript != null && GameManager.instance != null)
            {
                if (!GameManager.instance.asteriodList.Contains(asteroidScript))
                {
                    GameManager.instance.asteriodList.Add(asteroidScript);
                }
            }
            else
            {
                Debug.LogError("Spawned asteroid is missing its astriod script!");
            }

            spawned++;
        }

        Debug.Log("Asteroid Spawner created " + spawned + " asteroids.");
        if (GameManager.instance != null)
        {
            GameManager.instance.FinishAsteroidSpawning();
        }
    }
}