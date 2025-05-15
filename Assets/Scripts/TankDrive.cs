using UnityEngine;

public class TankDrive : MonoBehaviour, IDrive
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float turnSpeed = 90f;

    public void Drive(Transform body, float moveInput, float turnInput)
    {
        Vector3 forward = body.forward * moveInput * moveSpeed * Time.deltaTime;
        body.position += forward;

        float yaw = turnInput * turnSpeed * Time.deltaTime;
        body.Rotate(Vector3.up, yaw);
    }
}
