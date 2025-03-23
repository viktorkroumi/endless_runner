using UnityEngine;

public class FixedCamera : MonoBehaviour
{
    public Transform player;
    public float followStrength = 0.5f;
    public float maxOffsetX = 1.5f;

    private float startCameraX;
    private float fixedCameraY;

    void Start()
    {
        startCameraX = transform.position.x;
        fixedCameraY = transform.position.y;
    }

    void LateUpdate()
    {
        float targetX = startCameraX + (player.position.x * followStrength);
        targetX = Mathf.Clamp(targetX, startCameraX - maxOffsetX, startCameraX + maxOffsetX);
        transform.position = new Vector3(targetX, fixedCameraY, transform.position.z);
    }
}
