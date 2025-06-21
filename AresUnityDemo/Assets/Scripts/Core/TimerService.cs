using UnityEngine;
using System;
using System.Collections;

public class TimerService : MonoBehaviour
{
    [SerializeField] private float duration = 120f;

    public event Action<float> OnTimerTick;
    public event Action OnTimerFinished;
    public bool IsRunning { get; private set; }

    public void StartTimer()
    {
        IsRunning = true;
        StartCoroutine(RunTimer());
    }

    public void StopTimer()
    {
        IsRunning = false;
    }

    private IEnumerator RunTimer()
    {
        float elapsed = 0f;
        while (elapsed < duration && IsRunning)
        {
            elapsed += Time.deltaTime;
            float remaining = Mathf.Max(duration - elapsed, 0f);
            OnTimerTick?.Invoke(remaining);
            yield return null;
        }

        if (IsRunning)
            OnTimerFinished?.Invoke();

        IsRunning = false;
    }
}
