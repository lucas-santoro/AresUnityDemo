using UnityEngine;

public class Target : MonoBehaviour
{
    private IMovementPattern movementPattern;

    void Awake()
    {
        movementPattern = GetComponent<IMovementPattern>();
        if (movementPattern == null)
            Debug.LogWarning($"{name} without IMovementPattern!");
    }

    void OnEnable()
    {
        TargetManager.Instance?.Register();
    }

    void OnDisable()
    {
        TargetManager.Instance?.Unregister();
    }

    void Update()
    {
        movementPattern?.Move(transform);
    }
}
