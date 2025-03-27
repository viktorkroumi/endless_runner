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

        MoveToTargetPosition();
        DetectSwipe();
    }

    //https://discussions.unity.com/t/help-with-endless-runner-switching-lanes-solved/661810/4

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

    //https://learn.unity.com/tutorial/touch-input-for-mobile-scripting#5fc28c65edbc2a0d25685a9e 

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

    //https://discussions.unity.com/t/smooth-lane-change/635379/2

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