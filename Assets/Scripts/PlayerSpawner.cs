using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform spawnPoint;

    public GameObject SpawnPlayer()
    {
        if (playerPrefab == null || spawnPoint == null) return null;
        return Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
