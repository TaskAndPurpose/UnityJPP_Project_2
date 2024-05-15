using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Player Movement Settings")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform _tankTurretTransform;
    [SerializeField] private float _tankBodyMovementSpeed = 5.0f;
    [SerializeField] private float _tankBodyRotationSpeed = 100.0f;
    [SerializeField] private float _tankTurretRotationSpeed = 100.0f;





    void Update()
    {
        PlayerController();
    }

    private void PlayerController()
    {
        HandleVerticalMovement();
        HandleHorizontalMovement();
        HandleRotationMovement();

        HandleTurretRotation();

    }

    private void HandleTurretRotation()
    {
        if (mainCamera != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if (groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                Vector3 direction = (point - transform.position).normalized;

                Quaternion targetRotation = Quaternion.LookRotation(direction);
 

                _tankTurretTransform.rotation = Quaternion.RotateTowards(_tankTurretTransform.rotation, targetRotation, _tankTurretRotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            Debug.LogError("Main camera reference not set!");
        }

    }

    private void HandleVerticalMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveBackward();
        }
    }

    private void HandleHorizontalMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
    }

    private void HandleRotationMovement()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.E))
        {
            RotateRight();
        }
    }

    private void MoveForward()
    {
        Vector3 movement = transform.forward * _tankBodyMovementSpeed * Time.deltaTime;
        _rb.MovePosition(_rb.position + movement);
    }

    private void MoveBackward()
    {
        Vector3 movement = -transform.forward * _tankBodyMovementSpeed * Time.deltaTime;
        _rb.MovePosition(_rb.position + movement);
    }

    private void MoveLeft()
    {
        Vector3 movement = -transform.right * _tankBodyMovementSpeed * Time.deltaTime;
        _rb.MovePosition(_rb.position + movement);
    }

    private void MoveRight()
    {
        Vector3 movement = transform.right * _tankBodyMovementSpeed * Time.deltaTime;
        _rb.MovePosition(_rb.position + movement);
    }

    private void RotateLeft()
    {
        transform.Rotate(Vector3.up, -_tankBodyRotationSpeed * Time.deltaTime);
    }

    private void RotateRight()
    {
        transform.Rotate(Vector3.up, _tankBodyRotationSpeed * Time.deltaTime);
    }


}
