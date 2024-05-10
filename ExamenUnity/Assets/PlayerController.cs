using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    public CharacterController characterController;
    public float velocidadNormal = 12f;
    public float velocidadSprint = 20f;
    public float gravity = -9.81f;
    Vector3 velocidadGravedad;
    public Transform groundChecker;
    public float radioEsfera = 0.3f;
    public LayerMask groundMask;
    bool isGrounded;
    bool doubleJumpAvailable = true;
    public float jumpHeight = 3;
    private Vector3 respawnPosition = new Vector3(0f, 4f, 0f);

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, radioEsfera, groundMask);
        if (isGrounded && velocidadGravedad.y < 0)
        {
            velocidadGravedad.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        Vector3 move = transform.right * x;
        float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadSprint : velocidadNormal;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                velocidadGravedad.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                doubleJumpAvailable = true;
            }
            else if (doubleJumpAvailable)
            {
                velocidadGravedad.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                doubleJumpAvailable = false;
            }
        }

        characterController.Move(move * velocidadActual * Time.deltaTime);
        velocidadGravedad.y += gravity * Time.deltaTime;
        characterController.Move(velocidadGravedad * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isGrounded && transform.position.y < 0)
        {
            transform.position = respawnPosition;
        }
    }
}
