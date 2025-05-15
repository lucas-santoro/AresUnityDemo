using UnityEngine;

public class HorizontalMovement : MonoBehaviour, IMovementPattern
{
    private Vector2 speedRange = new Vector2(1f, 3f);
    private Vector2 amplitudeRange = new Vector2(0.5f, 2f);

    private float speed;
    private float amplitude;
    private float angle;
    private float originX;
    private float originZ;
    private bool moveAlongX;

    void Start()
    {
        speed = Random.Range(speedRange.x, speedRange.y);
        amplitude = Random.Range(amplitudeRange.x, amplitudeRange.y);
        originX = transform.position.x;
        originZ = transform.position.z;
        moveAlongX = Random.value < 0.5f;
    }

    public void Move(Transform t)
    {
        angle += speed * Time.deltaTime;
        float offset = Mathf.Sin(angle) * amplitude;

        if (moveAlongX)
            t.position = new Vector3(originX + offset, t.position.y, originZ);
        else
            t.position = new Vector3(originX, t.position.y, originZ + offset);
    }
}
