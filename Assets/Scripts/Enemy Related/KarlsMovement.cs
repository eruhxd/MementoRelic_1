using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento del enemigo
    public LayerMask groundLayer; // Capa que define las superficies con las que el enemigo puede chocar
    public float raycastDistance = 0.5f; // Distancia a la que se lanza el rayo para detectar superficies

    private Rigidbody2D rb;
    private bool movingRight = true; // Variable para controlar la direcci�n del movimiento

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Determinar la direcci�n de movimiento en funci�n de la variable movingRight
        Vector2 movement = movingRight ? Vector2.right : Vector2.left;

        // Convertir la posici�n del transform a Vector2 para evitar errores de tipo
        Vector2 raycastOrigin = new Vector2(transform.position.x, transform.position.y);

        // Lanzar un rayo hacia adelante para detectar si hay una superficie
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin + movement * raycastDistance, movement, raycastDistance, groundLayer);

        // Si el rayo golpea algo, cambiar la direcci�n de movimiento
        if (hit.collider != null)
        {
            movingRight = !movingRight; // Cambiar la direcci�n
            Flip(); // Llamar al m�todo Flip para voltear la orientaci�n del enemigo
        }

        // Mover al enemigo en la direcci�n determinada
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

    void Flip()
    {
        // Voltear la orientaci�n del sprite del enemigo
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}