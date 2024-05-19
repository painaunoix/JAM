using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public Transform cam;

    private float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Obtient la direction de déplacement en fonction de la rotation de la caméra
        Vector3 direction = GetCameraDirection(horizontal, vertical);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    Vector3 GetCameraDirection(float horizontal, float vertical)
    {
        // Récupère la direction de la caméra en fonction de la rotation actuelle de la caméra
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        // Ignore la composante Y pour que le joueur se déplace horizontalement sur le sol
        camForward.y = 0f;
        camRight.y = 0f;

        // Normalise les vecteurs de direction
        camForward.Normalize();
        camRight.Normalize();

        // Calcule la direction de déplacement basée sur les entrées horizontales et verticales et la rotation de la caméra
        Vector3 moveDirection = camForward * vertical + camRight * horizontal;
        moveDirection.Normalize();

        return moveDirection;
    }
}