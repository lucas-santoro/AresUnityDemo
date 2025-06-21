using UnityEngine;

public class CircularMovement : MonoBehaviour, IMovementPattern
{
    Vector2 speedRange = new Vector2(0.5f, 2f);
    Vector2 radiusRange = new Vector2(1f, 4f);
    Vector2 yawRange = new Vector2(0f, 360f);

    float speed;
    float radius;
    float angle;
    Vector3 center;
    Vector3 forwardDir;

    void Start()
    {
        speed = Random.Range(speedRange.x, speedRange.y);
        radius = Random.Range(radiusRange.x, radiusRange.y);
        float yaw = Random.Range(yawRange.x, yawRange.y) * Mathf.Deg2Rad;
        forwardDir = new Vector3(Mathf.Cos(yaw), 0f, Mathf.Sin(yaw));
        center = transform.position;
        angle = 0f;
    }

    public void Move(Transform t)
    {
        angle += Time.deltaTime * speed;
        float horiz = Mathf.Cos(angle) * radius;
        float newY = center.y + radius + Mathf.Sin(angle) * radius;
        Vector3 horizontal = forwardDir * horiz;
        t.position = new Vector3(center.x + horizontal.x, newY, center.z + horizontal.z);
    }
}
