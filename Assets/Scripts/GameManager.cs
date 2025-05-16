using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private Vector3 groundPosition;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private PlayerSpawner playerSpawner;
    [SerializeField] private TimerService timerService;

    private CombinedGameStarter gameStarter;

    void Awake()
    {
        gameStarter = GetComponent<CombinedGameStarter>();
        gameStarter.OnGameStart += InitializeGame;
    }

    void OnDestroy()
    {
        gameStarter.OnGameStart -= InitializeGame;
        timerService.OnTimerFinished -= HandleGameOver;
        TargetManager.Instance.OnAllTargetsKilled -= HandleGameOver;
    }

    void InitializeGame()
    {
        InputManager.Instance.EnableInput();
        SpawnGround();
        playerSpawner.SpawnPlayer();
        spawnManager.SpawnInitialTargets();
        timerService.OnTimerFinished += HandleGameOver;
        TargetManager.Instance.OnAllTargetsKilled += HandleGameOver;
        timerService.StartTimer();
    }

    void SpawnGround()
    {
        if (groundPrefab == null) return;
        Instantiate(groundPrefab, groundPosition, Quaternion.identity);
    }

    void HandleGameOver()
    {
        InputManager.Instance.DisableInput();
        Debug.Log("Game Over");
        timerService.StopTimer();
    }
}
