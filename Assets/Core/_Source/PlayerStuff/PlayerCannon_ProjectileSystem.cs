using UnityEngine;
using System.Collections; 

public class PlayerCannon_Projectile : MonoBehaviour
{
    // GameObject to shoot
    [SerializeField] private GameObject bulletPrefab;

    // spawn bullet here
    [SerializeField] private Transform firePoint;

    [SerializeField] private float shotCooldown = 1.5f; // Cooldown between shots

    private bool canShoot = true; // Flag to track if the turret can shoot

    // Update is called once per frame
    void Update()
    {
        // Check if the turret can shoot
        if (canShoot)
        {
            HandleTurret(); // Handle turret shooting based on player input
        }
    }

    // Handles turret shooting based on player input
    private void HandleTurret()
    {
        // Check if the player pressed the designated shoot key (in this case, F)
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // Instantiate a bullet at the fire point position with the same rotation as the fire point
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Start the cooldown coroutine
            StartCoroutine(ShotCooldown());
        }
    }

    // Coroutine to handle the shot cooldown
    private IEnumerator ShotCooldown()
    {
        // Set the flag to prevent shooting
        canShoot = false;

        // Wait for the cooldown period
        yield return new WaitForSeconds(shotCooldown);

        // Reset the flag to allow shooting again
        canShoot = true;
    }
}
