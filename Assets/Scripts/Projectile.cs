using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
