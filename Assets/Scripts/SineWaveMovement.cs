using UnityEngine;

public class SineWaveMovement : MonoBehaviour, IMovementPattern
{
    private Vector2 speedRange = new Vector2(0.5f, 2f);
    private Vector2 amplitudeRange = new Vector2(0.5f, 1.5f);
    private Vector2 frequencyRange = new Vector2(0.5f, 2f);
    private Vector2 distanceRange = new Vector2(5f, 15f);
    private Vector2 angleRange = new Vector2(0f, 360f);

    private float speed;
    private float amplitude;
    private float frequency;
    private float maxDistance;
    private float startTime;
    private Vector3 origin;
    private Vector3 forwardDir;

    void Start()
    {
        speed = Random.Range(speedRange.x, speedRange.y);
        amplitude = Random.Range(amplitudeRange.x, amplitudeRange.y);
        frequency = Random.Range(frequencyRange.x, frequencyRange.y);
        maxDistance = Random.Range(distanceRange.x, distanceRange.y);
        float yaw = Random.Range(angleRange.x, angleRange.y) * Mathf.Deg2Rad;

        forwardDir = new Vector3(Mathf.Cos(yaw), 0f, Mathf.Sin(yaw));

        origin = transform.position;
        startTime = Time.time;
    }

    public void Move(Transform t)
    {
        float ping = Mathf.PingPong((Time.time - startTime) * speed, maxDistance * 2f) - maxDistance;
        float yOffset = Mathf.Sin(ping * frequency) * amplitude;
        Vector3 horiz = forwardDir * ping;
        t.position = origin + horiz + Vector3.up * yOffset;
    }
}
