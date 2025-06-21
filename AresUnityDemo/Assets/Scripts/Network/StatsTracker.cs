using UnityEngine;

public class StatsTracker : MonoBehaviour
{
    private int shotsFired = 0;
    private int targetsHit = 0;
    private float startTime;

    void OnEnable()
    {
        startTime = Time.time;
        TurretShooter.OnRealFire += CountShot;
        TargetManager.Instance.OnTargetDestroyed += CountHit;
        TargetManager.Instance.OnAllTargetsKilled += ReportStats;
    }

    void OnDisable()
    {
        TurretShooter.OnRealFire -= CountShot;
        if (TargetManager.Instance != null)
        {
            TargetManager.Instance.OnTargetDestroyed -= CountHit;
            TargetManager.Instance.OnAllTargetsKilled -= ReportStats;
        }
    }

    void CountShot() => shotsFired++;
    void CountHit() => targetsHit++;

    public void ReportStats()
    {
        float elapsed = Time.time - startTime;
        Debug.Log($"[STATS] Time: {elapsed:F1}s | Shots: {shotsFired} | Hits: {targetsHit}");
    }
}
