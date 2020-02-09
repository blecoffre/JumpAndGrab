using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera = default;
    [SerializeField]
    private Rigidbody m_rigidbody = default;

    public CustomInputs controls;

    public float MoveSpeed = 15;
    public float RotationSpeed = 5;
    Vector3 inputDirection;
    private Vector3 movement;

    private Vector2 movementInput;

    public float JumpVelocity = 3.5f;
    public float FallMultiplier = 5;
    public float LowJump = 2;

    private bool m_isGrounded = false;

    private void Start()
    {
        controls.Player.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.Player.Jump.performed += ctx => Jump();

        Debug.Log("Default value : " + InputSystem.settings.defaultButtonPressPoint);
    }

    private void LateUpdate()
    {
        float h = movementInput.x;
        float v = movementInput.y;

        var targetInput = new Vector3(h, 0, v);
        inputDirection = Vector3.Lerp(inputDirection, targetInput, Time.deltaTime * 10f);

        //Camera Direction
        var cameraForward = mainCamera.transform.forward;
        var cameraRight = mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        //Try not to use var for roadshows or learning code
        Vector3 desiredDirection = cameraForward * inputDirection.z + cameraRight * inputDirection.x;

        //Why not just pass the vector instead of breaking it up only to remake it on the other side?
        MoveThePlayer(desiredDirection);

        JumpCheck();
    }

    void MoveThePlayer(Vector3 desiredDirection)
    {
        movement.Set(desiredDirection.x, 0f, desiredDirection.z);

        movement = movement * MoveSpeed * Time.deltaTime;

        m_rigidbody.MovePosition(transform.position + movement);
    } 

    void Jump()
    {
        m_rigidbody.velocity = transform.up * JumpVelocity;
    }

    void JumpCheck()
    {
        if (m_rigidbody.velocity.y < 0)
        {
            m_rigidbody.velocity += transform.up * Physics.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
        }
        else if (m_rigidbody.velocity.y > 0 && controls.Player.Jump.ReadValue<float>() >= InputSystem.settings.defaultButtonPressPoint)
        {
            m_rigidbody.velocity += transform.up * Physics.gravity.y * (LowJump - 1) * Time.deltaTime;
        }

        Debug.Log("Current Value : " + controls.Player.Jump.ReadValue<float>());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            m_isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.tag == "Ground")
        {
            m_isGrounded = false;
        }
    }
}
