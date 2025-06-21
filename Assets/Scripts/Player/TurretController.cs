using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] Transform chassis;
    [SerializeField] float yawSpeed = 60f;
    [SerializeField] float pitchSpeed = 30f;
    [SerializeField] Transform barrel;

    float pitch;
    Vector3 localOffset;

    void Awake()
    {
        localOffset = transform.position - chassis.position;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        float initial = barrel.localEulerAngles.x;
        pitch = initial > 180f ? initial - 360f : initial;
    }
    
    public void Aim(float yawInput, float pitchInput)
    {
        if (!InputManager.Instance.InputEnabled) return;

        transform.position = chassis.position + chassis.TransformDirection(localOffset);

        transform.Rotate(Vector3.up, yawInput * yawSpeed * Time.deltaTime, Space.World);

        pitch -= pitchInput * pitchSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -60f, 10f);
        barrel.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void LateUpdate()
    {
        // if (!InputManager.Instance.InputEnabled) return;
        // transform.position = chassis.position + chassis.TransformDirection(localOffset);

        // float dx = Input.GetAxis("Mouse X");
        // transform.Rotate(Vector3.up, dx * yawSpeed * Time.deltaTime, Space.World);

        // float dy = Input.GetAxis("Mouse Y");
        // pitch -= dy * pitchSpeed * Time.deltaTime;
        // pitch = Mathf.Clamp(pitch, -60f, 10f);
        // barrel.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}
