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
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");
        drive.Drive(chassis, moveInput, turnInput);
    }
}
