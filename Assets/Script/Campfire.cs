using UnityEngine;

public class Campfire : MonoBehaviour
{
    public ParticleSystem fireParticles;
    private bool playerInRange;

    void Start()
    {
        fireParticles.Stop();
        playerInRange = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!fireParticles.isPlaying)
            {
                fireParticles.Play();
            }
        }
    }
}
