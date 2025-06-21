using UnityEngine;

public class TargetInitializer : MonoBehaviour
{
    private Vector2 scaleRange = new Vector2(0.5f, 1.5f);

    void Start()
    {
        float s = Random.Range(scaleRange.x, scaleRange.y);
        transform.localScale = Vector3.one * s;
    }
}
