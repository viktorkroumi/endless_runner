using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float laneDistance = 3f;
    public float laneSwitchSpeed = 12f;
    public float jumpForce = 5f;

    private int currentLane = 1;
    private bool isGrounded = true;
    private Rigidbody rb;
    private Vector3 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        speed += 0.1f * Time.deltaTime;

        Move();
        MoveToTargetPosition();
    }

    void Move() 
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (currentLane < 2)
            {
                currentLane++;
                targetPosition = new Vector3(currentLane * laneDistance - laneDistance, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (currentLane > 0)
            {
                currentLane--;
                targetPosition = new Vector3(currentLane * laneDistance - laneDistance, transform.position.y, transform.position.z);
            }
        }
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            Jump();
        }
    }

    void MoveToTargetPosition()
    {
        transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, targetPosition.x, laneSwitchSpeed * Time.deltaTime), transform.position.y, transform.position.z);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
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
