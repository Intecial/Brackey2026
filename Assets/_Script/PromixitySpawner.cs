using UnityEngine;

public class ProximitySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject prefabToSpawn;
    public float spawnRadius = 50f;
    public int minObjects = 10;
    public int maxObjects = 30;

    [Header("Scaling & Rotation")]
    public float minScale = 1f;
    public float maxScale = 4f;
    [Range(0, 360)] public float maxRotationY = 360f;

    [Header("Collision Logic")]
    public LayerMask obstacleLayer;
    public int maxAttempts = 15;

    void Start()
    {
        GenerateObjects();
    }

    void GenerateObjects()
    {
        int targetCount = Random.Range(minObjects, maxObjects + 1);

        for (int i = 0; i < targetCount; i++)
        {
            TryPlaceObject();
        }
    }

    void TryPlaceObject()
    {
        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            // 1. Pick a random point
            Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPos = transform.position + new Vector3(randomCircle.x, 0, randomCircle.y);

            // 2. Determine random scale
            float scale = Random.Range(minScale, maxScale);

            // 3. Determine random rotation (Y-axis only)
            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, maxRotationY), 0);

            // 4. Check for overlaps 
            // We check a sphere slightly larger than half the scale to ensure breathing room
            float checkRadius = scale * 0.6f;

            if (!Physics.CheckSphere(spawnPos, checkRadius, obstacleLayer))
            {
                GameObject obj = Instantiate(prefabToSpawn, spawnPos, randomRotation);
                obj.transform.localScale = Vector3.one * scale;

                // Ensure the object is on the correct layer for the next check
                obj.layer = (int)Mathf.Log(obstacleLayer.value, 2);
                return;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}