using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;
    public bool isGrounded;

    private PlayerAnimation playerAnimation;

    void Start()
    {
        // Hide and lock cursor on startup
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerAnimation = this.GetComponent<PlayerAnimation>();
    }


    // Update is called once per frame
    void Update()
    {
        // Unlock and show cursor if user holds esc
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Jumps

        isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = 0f;

        if (isGrounded && Input.GetKeyDown(KeyCode.Space) && !playerAnimation.IsJumping)
        {
            playerAnimation.IsJumping = true;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // Movements
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            playerAnimation.IsRunning = true;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            playerAnimation.IsRunning = false;
        }
    }
}
