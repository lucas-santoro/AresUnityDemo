using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] Transform chassis;
    IDrive drive;

    void Awake()
    {
        drive = GetComponent<IDrive>();
    }
    
    void Update()
    {
        if (!InputManager.Instance.InputEnabled) return;
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");
        drive.Drive(chassis, moveInput, turnInput);
    }
}
