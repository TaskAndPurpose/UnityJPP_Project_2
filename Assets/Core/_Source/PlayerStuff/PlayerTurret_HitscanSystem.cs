using UnityEngine;
using UnityEngine;

public class PlayerTurretHitscanSystem : MonoBehaviour
{
    public Transform firePoint;            // Point from which bullets are fired
    public float weaponRange = 10f;        // Maximum range of the weapon
    public TrailRenderer bulletTrail;      // Visual representation of the bullet trail
    public LayerMask targetLayer;          // Layer mask for the raycast

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector3 endPoint = firePoint.position + firePoint.forward * weaponRange;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out RaycastHit hit, weaponRange, targetLayer))
        {
            endPoint = hit.point;
            HandleHit(hit.collider);
        }

        RenderTrail(firePoint.position, endPoint);
        Debug.Log(hit.collider != null ? "Hit: " + hit.collider.name : "No hit detected.");
    }

    private void HandleHit(Collider collider)
    {
        Debug.Log("Bullet collided with " + collider.name);



        if (collider.CompareTag("Barrel"))
        {
            //get the health system of the barrel in child
            HealthSystem healthSystem = collider.GetComponentInChildren<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.TakeDamage(0.1f);
                Debug.Log("Barrel health: " + healthSystem.health);
            }
        }
    }

    private void RenderTrail(Vector3 start, Vector3 end)
    {
        TrailRenderer trail = Instantiate(bulletTrail, start, Quaternion.identity);
        trail.AddPosition(start);
        trail.transform.position = end;
        trail.AddPosition(end);
        Destroy(trail.gameObject, trail.time);
    }
}
