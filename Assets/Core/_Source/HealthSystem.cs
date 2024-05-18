using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    // Current health of the object
    [SerializeField] public float health = 1f;

    // Maximum health of the object
    private const float maxHealth = 1f;

    // Image UI for health
    [SerializeField] private Image healthImage;

    // Take damage
    public void TakeDamage(float damage)
    {
        // Subtract the damage from the health and clamp it between 0 and maxHealth
        health = Mathf.Clamp(health - damage, 0f, maxHealth);
        UpdateHealthUi();

        // Check if the health is less than or equal to 0
        if (health <= 0)
        {
       
            Destroy(transform.parent.gameObject);
           //Destroy(gameObject);
        }
    }

  

    //Needs to be in update to always update the ui based on the var
    private void UpdateHealthUi()
    {
        if (healthImage != null)
        {
            // Update the health image fill amount
            healthImage.fillAmount = health / maxHealth;
        }
    }

    private void Start()
    {
        // Ensure health is clamped on start
        health = Mathf.Clamp(health, 0f, maxHealth);

        // Update Image UI
        UpdateHealthUi();

   
    }

   
}
