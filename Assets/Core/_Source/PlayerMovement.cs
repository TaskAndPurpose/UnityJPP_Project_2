using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Component References")]
    [SerializeField] private Camera mainCamera; // Reference to the main camera
    [SerializeField] private Rigidbody rb; // Reference to the Rigidbody component

    [Header("Player Settings")]
    [SerializeField] private float movementSpeed = 5.0f; // Movement speed of the player
    [SerializeField] private float rotationSpeed = 500.0f; // Rotation speed of the player



    //Monobehaviour Methods
    void Update()
    {
        HandleMovement();
        HandleRotation();
    }


    /// <summary>
    /// Class Methods
    /// </summary>


    // Classic Transform and RB movement
    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        Vector3 movement = movementDirection * movementSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + movement);
    }


    //Using Camera and Raycast to handle  rotation
    private void HandleRotation()
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
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            Debug.LogError("Main camera reference not set!");
        }
    }
}
