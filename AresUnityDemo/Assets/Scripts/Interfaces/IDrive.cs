using UnityEngine;

public interface IDrive
{
    void Drive(Transform body, float moveInput, float turnInput);
}
