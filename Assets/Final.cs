using UnityEngine;

public class Final : MonoBehaviour
{
    public ParticleSystem fireParticles;
    public ParticleSystem firework;
    public ParticleSystem firework2;
    private bool playerInRange;
    [SerializeField]
    private GameObject text;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        fireParticles.Stop();
        firework.Stop();
        firework2.Stop();
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
                    firework2.Play();
                    firework.Play();
                }
            }
        }
        if (!playerInRange || fireParticles.isPlaying)
        {
            text.SetActive(false);
        }

    }
}
