using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float laneDistance = 3f;
    public float laneSwitchSpeed = 15f;
    public float jumpForce = 5f;

    private int currentLane = 1;
    private bool isGrounded = true;
    private Rigidbody rb;
    private Vector3 targetPosition;

    private Vector2 startTouchPosition;
    public float swipeThreshold = 180f;
    
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
        DetectSwipe();
    }

    void Move() 
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            Jump();
        }
    }

    void MoveRight()
    {
        if (currentLane < 2)
        {
            currentLane++;
            targetPosition = new Vector3(currentLane * laneDistance - laneDistance, transform.position.y, transform.position.z);
        }
    }

    void MoveLeft()
    {
        if (currentLane > 0)
        {
            currentLane--;
            targetPosition = new Vector3(currentLane * laneDistance - laneDistance, transform.position.y, transform.position.z);
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void DetectSwipe()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 swipeDelta = touch.position - startTouchPosition;

                if (swipeDelta.magnitude > swipeThreshold)
                {
                    if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                    {
                        if (swipeDelta.x > 0)
                        {
                            MoveRight();
                        }
                        else
                        {
                            MoveLeft();
                        }    
                    }
                    else if (swipeDelta.y > 0)
                    {
                        Jump();
                    }

                    startTouchPosition = touch.position;
                }
            }
        }
    }

    void MoveToTargetPosition()
    {
        transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, targetPosition.x, laneSwitchSpeed * Time.deltaTime), transform.position.y, transform.position.z);
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