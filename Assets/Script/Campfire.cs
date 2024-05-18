using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public ParticleSystem fireParticles;
    private bool playerInRange;
    [SerializeField]
    private GameObject text;
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
        if (playerInRange)
        {
            text.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!fireParticles.isPlaying)
                {
                    fireParticles.Play();
                }
            }
        }
        if (!playerInRange || fireParticles.isPlaying)
        {
            text.SetActive(false);
        }
    }
}
