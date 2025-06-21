using UnityEngine;
using System;
public class TurretShooter : MonoBehaviour, IShooter
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform muzzlePoint;
    [SerializeField] float launchForce = 20f;
    [SerializeField] float fireCooldown = 0.2f;

    private float lastFireTime = -999f;
    public static event Action OnRealFire;

    void Update()
    {
        // if (!InputManager.Instance.InputEnabled) return;
        // if (Input.GetMouseButtonDown(0))
        //     Fire();
    }

    public void Fire()
    {
        if (Time.time - lastFireTime < fireCooldown) return;
        if (projectilePrefab == null || muzzlePoint == null) return;
        var projectile = Instantiate(projectilePrefab, muzzlePoint.position, muzzlePoint.rotation);
        var rigidb = projectile.GetComponent<Rigidbody>();
        if (rigidb)
            rigidb.linearVelocity = muzzlePoint.forward * launchForce;

        lastFireTime = Time.time;
        OnRealFire?.Invoke();
    }
}
