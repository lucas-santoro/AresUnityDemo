using UnityEngine;
using System;
using System.Diagnostics;

public class TargetManager : MonoBehaviour
{
    public static TargetManager Instance { get; private set; }
    public event Action<int> OnAliveCountChanged;
    public event Action OnAllTargetsKilled;
    public event Action OnTargetDestroyed;

    private int aliveCount;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Register()
    {
        aliveCount++;
        OnAliveCountChanged?.Invoke(aliveCount);
    }

    public void Unregister()
    {
        aliveCount--;
        OnAliveCountChanged?.Invoke(aliveCount);
        OnTargetDestroyed?.Invoke();

        if (aliveCount <= 0)
        {
            OnAllTargetsKilled?.Invoke();
        }
    }

    public int GetAliveCount()
    {
        return aliveCount;
    }
}
