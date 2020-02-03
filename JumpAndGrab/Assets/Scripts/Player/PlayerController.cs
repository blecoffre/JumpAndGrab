using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Rigidbody m_rigidbody;

    private CustomInputs controls;

    public float MoveSpeed = 15;
    public float RotationSpeed = 5;
    Vector3 inputDirection;
    private Vector3 movement;

    private Vector2 movementInput;
    Vector2 lookPosition;

    private void Awake()
    {
        controls = new CustomInputs();
        controls.Player.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.Player.Direction.performed += ctx => lookPosition = ctx.ReadValue<Vector2>();


    }

    void Start()
    {

    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
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
        TurnThePlayer();
    }

    void MoveThePlayer(Vector3 desiredDirection)
    {
        movement.Set(desiredDirection.x, 0f, desiredDirection.z);

        movement = movement * MoveSpeed * Time.deltaTime;

        m_rigidbody.MovePosition(transform.position + movement);

    }

    void TurnThePlayer()
    {

        // Old Input system
        Vector2 input = lookPosition;

        // Convert "input" to a Vector3 where the Y axis will be used as the Z axis
        Vector3 lookDirection = new Vector3(input.x, 0, input.y);
        var lookRot = mainCamera.transform.TransformDirection(lookDirection);
        lookRot = Vector3.ProjectOnPlane(lookRot, Vector3.up);

        if (lookRot != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(lookRot);
            m_rigidbody.MoveRotation(newRotation);
        }
    }
}
