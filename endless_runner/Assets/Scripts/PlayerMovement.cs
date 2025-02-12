using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    public float laneDistance = 4f;
    public float jumpForce = 5f;

    private int currentLane = 1;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        MoveToLane();
    }

    void MoveToLane() 
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (currentLane < 2)
            {
                currentLane++;
                transform.position += new Vector3(laneDistance, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (currentLane > 0)
            {
                currentLane--;
                transform.position += new Vector3(-laneDistance, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
