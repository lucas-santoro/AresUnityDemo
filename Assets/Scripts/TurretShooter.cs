using UnityEngine;

public class TurretShooter : MonoBehaviour, IShooter
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform muzzlePoint;
    [SerializeField] float launchForce = 20f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Fire();
    }

    public void Fire()
    {
        if (projectilePrefab == null || muzzlePoint == null) return;
        var projectile = Instantiate(projectilePrefab, muzzlePoint.position, muzzlePoint.rotation);
        var rigidb = projectile.GetComponent<Rigidbody>();
        if (rigidb)
            rigidb.linearVelocity = muzzlePoint.forward * launchForce;
    }
}
