using UnityEngine;

public class RotateAlongXAxis : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation

    void Update()
    {
        // Rotate around the x-axis
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
