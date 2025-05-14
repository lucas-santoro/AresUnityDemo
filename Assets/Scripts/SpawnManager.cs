using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("References (assign in Inspector)")]
    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject targetPrefab;

    [Header("Spawn Settings")]
    [SerializeField] private int initialTargetCount = 5;
    [SerializeField] private float maxTargetHeight = 20f;

    public void SpawnInitialTargets()
    {
        for (int i = 0; i < initialTargetCount; i++)
            SpawnOne();
    }

    public GameObject SpawnOne()
    {
        Vector3 pos = GetRandomPosition();
        var go = Instantiate(targetPrefab, pos, Quaternion.identity);
        Debug.Log($"Spawned target at {pos}");
        return go;
    }

    private Vector3 GetRandomPosition()
    {
        if (ground == null)
        {
            Debug.LogError("SpawnManager: Ground reference not set");
            return Vector3.zero;
        }
        Renderer renderer = ground.GetComponent<Renderer>();

        float width = renderer.bounds.size.x;
        float depth = renderer.bounds.size.z;
        float groundY = ground.transform.position.y;

        float x = Random.Range(-width / 2f, width / 2f) + ground.transform.position.x;
        float z = Random.Range(-depth / 2f, depth / 2f) + ground.transform.position.z;
        float y = groundY + Random.Range(0f, maxTargetHeight);

        return new Vector3(x, y, z);
    }
}
