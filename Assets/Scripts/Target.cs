using UnityEngine;
using System.Linq;

public class Target : MonoBehaviour
{
    private IMovementPattern _pattern;

    void Awake()
    {
        _pattern = GetComponent<IMovementPattern>();
        if (_pattern == null)
            Debug.LogWarning($"{name} without IMovementPattern!");
    }

    void Update()
    {
        _pattern?.Move(transform);
    }
}
