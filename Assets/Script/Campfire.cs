using UnityEngine;

public class Campfire : MonoBehaviour
{
    public ParticleSystem fireParticles; // Référence au système de particules du feu
    private bool playerInRange; // Pour savoir si le joueur est dans la zone

    void Start()
    {
        fireParticles.Stop(); // Assurez-vous que le feu est éteint au départ
        playerInRange = false; // Le joueur n'est pas dans la zone au départ
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
                fireParticles.Play(); // Allume le feu
            }
        }
    }
}
