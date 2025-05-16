using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public bool InputEnabled { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void EnableInput() => InputEnabled = true;
    public void DisableInput() => InputEnabled = false;
}
