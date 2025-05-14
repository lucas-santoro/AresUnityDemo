using UnityEngine;
using System;
using System.Collections;

public class TimerService : MonoBehaviour
{
    [SerializeField] private float duration = 120f;
    public event Action OnTimerFinished;

    public void StartTimer()
    {
        StartCoroutine(RunTimer());
    }

    private IEnumerator RunTimer()
    {
        yield return new WaitForSeconds(duration);
        OnTimerFinished?.Invoke();
    }
}
