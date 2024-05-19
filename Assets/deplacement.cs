using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 5f; // Vitesse de la voiture
    public float distance = 10f; // Distance à parcourir

    private Vector3 startPoint;
    private Vector3 endPoint;
    private bool goingForward = true;

    private Transform playerTransform = null;
    private Vector3 playerOffset;

    void Start()
    {
        startPoint = transform.position;
        endPoint = startPoint + transform.forward * distance;
    }

    void Update()
    {
        MoveCar();
        MovePlayer();
    }

    void MoveCar()
    {
        if (goingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, endPoint) < 0.1f)
            {
                goingForward = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, startPoint) < 0.1f)
            {
                goingForward = true;
            }
        }
    }

    void MovePlayer()
    {
        if (playerTransform != null)
        {
            playerTransform.position = transform.position + playerOffset;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
            playerOffset = playerTransform.position - transform.position;
            Debug.Log("Player entered the car");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = null;
            Debug.Log("Player exited the car");
        }
    }
}
