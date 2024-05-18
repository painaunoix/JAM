using UnityEngine;

public class Campfire : MonoBehaviour
{
    public ParticleSystem fireParticles; // R�f�rence au syst�me de particules du feu
    private bool playerInRange; // Pour savoir si le joueur est dans la zone

    void Start()
    {
        fireParticles.Stop(); // Assurez-vous que le feu est �teint au d�part
        playerInRange = false; // Le joueur n'est pas dans la zone au d�part
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
