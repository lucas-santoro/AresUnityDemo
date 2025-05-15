using UnityEngine;
using System;
using System.Collections;

public class TimerService : MonoBehaviour
{
    [SerializeField] private float duration = 120f;
    public event Action<float> OnTimerTick;
    public event Action OnTimerFinished;

    public void StartTimer()
    {
        StartCoroutine(RunTimer());
    }

    private IEnumerator RunTimer()
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float remaining = Mathf.Max(duration - elapsed, 0f);
            OnTimerTick?.Invoke(remaining);
            yield return null;
        }

        OnTimerFinished?.Invoke();
    }
}
