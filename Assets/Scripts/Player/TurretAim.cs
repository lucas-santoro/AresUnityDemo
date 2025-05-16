using UnityEngine;

public class TurretAim : MonoBehaviour, ITurretAim
{
    [SerializeField] float rotationSpeed = 60f;

    public void Aim(Transform turret, Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - turret.position;
        direction.y = 0;
        if (direction.sqrMagnitude < 0.0001f) return;
        Quaternion desired = Quaternion.LookRotation(direction);
        turret.rotation = Quaternion.Lerp(turret.rotation, desired, rotationSpeed * Time.deltaTime);
    }
}
