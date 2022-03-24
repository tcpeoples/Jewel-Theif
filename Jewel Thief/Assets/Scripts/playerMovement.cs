using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerMovement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float jumpButtonGrace;
    public float threshold;
    public bool isJumping;
    public bool isGrounded;
    public int playerLives = 3;

    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGrounded;
    private float? jumpButtonPressed;
    private Animator animator;


    void Start()
    {

        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Debug.Log($"Horizontal input: {horizontal}, Vertical input: {vertical}");

        Vector3 movementDirection = new Vector3(horizontal, 0, vertical);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            lastGrounded = Time.time;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonPressed = Time.time;
        }

        if(Time.time - lastGrounded <= jumpButtonGrace)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            animator.SetBool("isGrounded", true);
            isGrounded = true;
            animator.SetBool("isJumping", false);
            isJumping = false;
            animator.SetBool("isFalling", false);

            if(Time.time - jumpButtonPressed <= jumpButtonGrace)
            {
                ySpeed = jumpSpeed;
                animator.SetBool("isJumping", true);
                isJumping = true;
                jumpButtonPressed = null;
                lastGrounded = null;
            }
        }
        else
        {
            characterController.stepOffset = 0;
            animator.SetBool("isGrounded", false);
            isGrounded = false;

            if((isJumping && ySpeed < 0) || ySpeed < -2)
            {
                animator.SetBool("isFalling", true);
            }
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;
        characterController.Move(velocity * Time.deltaTime);

        if(movementDirection != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        transform.position += movementDirection * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (transform.position.y < threshold)
            transform.position = new Vector3(0, 0, -24);

    }

}
