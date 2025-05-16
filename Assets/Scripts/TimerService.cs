using UnityEngine;
using System;
using System.Collections;

public class TimerService : MonoBehaviour
{
    [SerializeField] private float duration = 120f;

    public event Action<float> OnTimerTick;
    public event Action OnTimerFinished;

    private bool isRunning = false;

    public void StartTimer()
    {
        isRunning = true;
        StartCoroutine(RunTimer());
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private IEnumerator RunTimer()
    {
        float elapsed = 0f;
        while (elapsed < duration && isRunning)
        {
            elapsed += Time.deltaTime;
            float remaining = Mathf.Max(duration - elapsed, 0f);
            OnTimerTick?.Invoke(remaining);
            yield return null;
        }

        if (isRunning)
            OnTimerFinished?.Invoke();

        isRunning = false;
    }
}
