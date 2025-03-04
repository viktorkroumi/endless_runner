using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float laneDistance = 3f;
    public float jumpForce = 5f;

    private int currentLane = 1;
    private bool isGrounded = true;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        speed += 0.1f * Time.deltaTime;

        Move();
    }

    void Move() 
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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded || Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    //https://stackoverflow.com/questions/65488572/how-do-i-limit-a-gameobject-to-jump-only-once
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
