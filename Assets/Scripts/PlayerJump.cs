using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Componentes
    private Rigidbody2D rb;

    // Variables para el salto
    public float jumpForce = 10f;         // La fuerza de salto base
    public float maxJumpTime = 0.5f;      // El tiempo máximo que se puede mantener el botón para el salto
    public float minJumpForce = 3f;       // La fuerza mínima para el salto
    public float jumpHoldForce = 1f;      // Fuerza adicional mientras se mantiene el botón presionado

    // Control interno del tiempo de salto
    private bool isJumping = false;
    private bool isGrounded = false;
    private float jumpTimeCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Iniciar el salto
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            jumpTimeCounter = maxJumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Continuar saltando mientras se mantenga el botón
        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpHoldForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        // Terminar el salto cuando se suelte el botón
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            if (rb.velocity.y > minJumpForce)
            {
                rb.velocity = new Vector2(rb.velocity.x, minJumpForce);
            }
        }
    }

    // Detecta cuando el personaje colisiona con el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Detecta cuando el personaje deja de colisionar con el suelo
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}