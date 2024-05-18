using UnityEngine;

public class Barrel : MonoBehaviour
{

    //header 
    [Header("Barrel Properties")]
    //box collider
    [SerializeField] private BoxCollider _bc;
    //mesh render material 
    [SerializeField] private Material _myCurrentmat;
    //refference to barrel healthSystem
    [SerializeField] private HealthSystem _barrelHealthSystem;
    //refference to particle system
    [SerializeField] private ParticleSystem _explosionParticle;



    // On Destroy
    private void BarrelDestroyed()
    {
        // Instantiate the explosion particle
        Instantiate(_explosionParticle, transform.position, Quaternion.identity);
        // Destroy the game object
        Destroy(gameObject, 2f);
    }
    
    





}
