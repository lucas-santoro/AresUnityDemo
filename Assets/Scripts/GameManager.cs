using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Service References (assign in Inspector)")]
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private TimerService timerService;

    private void Start()
    {
        spawnManager.SpawnInitialTargets();

        timerService.OnTimerFinished += HandleGameOver;
        TargetManager.Instance.OnAllTargetsKilled += HandleGameOver;

        timerService.StartTimer();
    }

    private void HandleGameOver()
    {
        Debug.Log("Game Over");
        timerService.StopTimer();
    }

    private void OnDestroy()
    {
        if (timerService != null)
            timerService.OnTimerFinished -= HandleGameOver;

        if (TargetManager.Instance != null)
            TargetManager.Instance.OnAllTargetsKilled -= HandleGameOver;
    }
}
