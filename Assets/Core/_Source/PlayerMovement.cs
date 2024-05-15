using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Player Movement Settings")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _movementSpeed = 5.0f;
    [SerializeField] private float _rotationSpeed = 100.0f;

    void Update()
    {
        PlayerController();
    }

    private void PlayerController()
    {
        HandleVerticalMovement();
        HandleHorizontalMovement();
        HandleRotationMovement();
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
        Vector3 movement = transform.forward * _movementSpeed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void MoveBackward()
    {
        Vector3 movement = -transform.forward * _movementSpeed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void MoveLeft()
    {
        Vector3 movement = -transform.right * _movementSpeed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void MoveRight()
    {
        Vector3 movement = transform.right * _movementSpeed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void RotateLeft()
    {
        transform.Rotate(Vector3.up, -_rotationSpeed * Time.deltaTime);
    }

    private void RotateRight()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
