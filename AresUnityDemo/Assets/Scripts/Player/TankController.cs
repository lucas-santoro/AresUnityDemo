using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] Transform chassis;
    IDrive drive;

    void Awake()
    {
        drive = GetComponent<IDrive>();
    }

    public void Drive(float move, float turn)
    {
        if (!InputManager.Instance.InputEnabled) return;
        drive.Drive(chassis, move, turn);
    }
    
    void Update()
    {
        // if (!InputManager.Instance.InputEnabled) return;
        // float moveInput = Input.GetAxis("Vertical");
        // float turnInput = Input.GetAxis("Horizontal");
        // drive.Drive(chassis, moveInput, turnInput);
    }
}
