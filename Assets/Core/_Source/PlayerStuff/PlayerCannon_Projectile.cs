using UnityEngine;

public class PlayerCannon : MonoBehaviour
{
    //HEADER Bullet Settings
    [Header("Bullet Settings")]
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _timeTillDespawn = 6.0f;
    [SerializeField] private float _damage = .2f;






    private void Start()
    {
        //Destroy the bullet after 6 seconds
        Destroy(gameObject, 6.0f);
    }



    private void Update()
    {
        // Move the bullet
        MoveBullet();
    }


    /// <summary>
    /// MB ABOVE, Local Methods Below
    /// </summary>


    private void MoveBullet()
    {
        //move the bullet forward based on the speed
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        // see what u shit
        Debug.Log("collidewd with" + collision);
    }


    // on trigger enter
    private void OnTriggerEnter(Collider _someArg)
    {
        if (_someArg)
        {
            //destroy self
            Destroy(gameObject, .2f);
        }

        // Check if the collided object has the tag "Barrel"
        if (_someArg.gameObject.CompareTag("Barrel"))
        {
            // Attempt to get the HealthSystem component from the collided object or its children
            HealthSystem healthSystem = _someArg.gameObject.GetComponentInChildren<HealthSystem>();

            // If the HealthSystem component is found
            if (healthSystem != null)
            {
                // Log the collision event
                Debug.Log("Bullet collided with " + _someArg.gameObject.name);

                // Apply damage to the health system
                healthSystem.TakeDamage(0.50f);

                //DESTROY SELF
                Destroy(gameObject,1.0f);
            }
            else
            {
                // Log a warning if the HealthSystem component is not found
                Debug.LogWarning("No HealthSystem component found on " + _someArg.gameObject.name + " or its children.");
            }

        }

    }
}
