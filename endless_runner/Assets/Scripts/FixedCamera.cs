using UnityEngine;

public class FixedCamera : MonoBehaviour
{
    private float fixedCameraX;

    void Start()
    {
        fixedCameraX = transform.position.x;
    }

    
    void LateUpdate()
    {
        transform.position = new Vector3(fixedCameraX, transform.position.y, transform.position.z);
    }
}
