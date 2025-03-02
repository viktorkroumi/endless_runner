using UnityEngine;

public class FixedCamera : MonoBehaviour
{
    private float fixedX;

    void Start()
    {
        fixedX = transform.position.x;
    }

    
    void LateUpdate()
    {
        transform.position = new Vector3(fixedX, transform.position.y, transform.position.z);
    }
}
