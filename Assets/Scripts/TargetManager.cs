using UnityEngine;
using System;

public class TargetManager : MonoBehaviour
{
    public static TargetManager Instance { get; private set; }
    public event Action<int> OnAliveCountChanged;

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
    }

    public int GetAliveCount()
    {
        return aliveCount;
    }
}
