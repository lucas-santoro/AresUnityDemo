using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject targetPrefab;
    public int initialTargetCount = 5;
    public Vector2 spawnAreaSize = new Vector2(10f, 10f);
    public float maxTargetHeight = 20.0f;

    [Header("Game Timer")]
    public float gameDuration = 120f;

    private GameObject ground;

    void Start()
    {
        CreateGround();
        SpawnTargets();
        StartCoroutine(GameTimer());
    }

    void CreateGround()
    {
        ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.name = "Ground";
        ground.transform.position = Vector3.zero;

        ground.transform.localScale = new Vector3(spawnAreaSize.x, 1, spawnAreaSize.y);
    }

    void SpawnTargets()
    {
        for (int i = 0; i < initialTargetCount; i++)
        {
            Vector3 pos = GetRandomPosition();
            Instantiate(targetPrefab, pos, Quaternion.identity);
            Debug.Log($"Spawned at Y: {pos.y}");

        }
    }

    Vector3 GetRandomPosition()
    {
        float groundWidth = ground.transform.localScale.x * 10f;
        float groundDepth = ground.transform.localScale.z * 10f;

        float x = Random.Range(-groundWidth / 2f, groundWidth / 2f);
        float z = Random.Range(-groundDepth / 2f, groundDepth / 2f);
        float y = ground.transform.position.y + Random.Range(0f, maxTargetHeight);


        return new Vector3(x, y, z);
    }

    IEnumerator GameTimer()
    {
        float elapsed = 0f;
        while (elapsed < gameDuration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Game Over");
    }
}
