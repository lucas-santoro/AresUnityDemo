using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class CombinedGameStarter : MonoBehaviour, IGameStarter
{
    public bool IsStarted { get; private set; }
    public event Action OnGameStart;
    [SerializeField] private GameObject menuCamera;
    [SerializeField] private GameObject uiRoot;

    delegate void GameStartCallback();
    [DllImport("AresGameInput")]
    static extern void RegisterGameStartCallback(GameStartCallback cb);

    void Awake()
    {
        try
        {
            RegisterGameStartCallback(OnNativeGameStart);
        }
        catch (DllNotFoundException)
        {
            Debug.Log("AresGameInput not found");
        }
    }


    void Update()
    {
        if (!IsStarted && Input.anyKeyDown)
            TriggerStart();
    }

    public void OnNativeGameStart()
    {
        TriggerStart();
    }

    void TriggerStart()
    {
        if (IsStarted) return;
        IsStarted = true;
        if (menuCamera != null) menuCamera.SetActive(false);
        if (uiRoot) uiRoot.SetActive(true);
        OnGameStart?.Invoke();
        enabled = false;
    }
}
