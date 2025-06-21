using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private Vector3 groundPosition;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private PlayerSpawner playerSpawner;
    [SerializeField] private TimerService timerService;
    [SerializeField] private GameStatsReporter statsReporter;
    [SerializeField] private CommandProcessor commandProcessor;

    private CombinedGameStarter gameStarter;
    public static GameObject PlayerInstance { get; private set; }

    void Awake()
    {
        gameStarter = GetComponent<CombinedGameStarter>();
        gameStarter.OnGameStart += InitializeGame;

        if (commandProcessor != null)
        commandProcessor.OnExitCommand += HandleGameOver;
    }

    void OnDestroy()
    {
        gameStarter.OnGameStart -= InitializeGame;

        if (timerService != null)
            timerService.OnTimerFinished -= HandleGameOver;

        if (TargetManager.Instance != null)
            TargetManager.Instance.OnAllTargetsKilled -= HandleGameOver;

        if (commandProcessor != null)
        {
            commandProcessor.OnExitCommand -= HandleGameOver;
        }

    }
    void InitializeGame()
    {
        InputManager.Instance.EnableInput();
        SpawnGround();
        PlayerInstance = playerSpawner.SpawnPlayer();
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
        statsReporter.SendGameStats();
    }
}
