using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento del enemigo
    public LayerMask groundLayer; // Capa que define las superficies con las que el enemigo puede chocar
    public float raycastDistance = 0.5f; // Distancia a la que se lanza el rayo para detectar superficies

    private Rigidbody2D rb;
    private bool movingRight = true; // Variable para controlar la dirección del movimiento

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Determinar la dirección de movimiento en función de la variable movingRight
        Vector2 movement = movingRight ? Vector2.right : Vector2.left;

        // Convertir la posición del transform a Vector2 para evitar errores de tipo
        Vector2 raycastOrigin = new Vector2(transform.position.x, transform.position.y);

        // Lanzar un rayo hacia adelante para detectar si hay una superficie
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin + movement * raycastDistance, movement, raycastDistance, groundLayer);

        // Si el rayo golpea algo, cambiar la dirección de movimiento
        if (hit.collider != null)
        {
            movingRight = !movingRight; // Cambiar la dirección
            Flip(); // Llamar al método Flip para voltear la orientación del enemigo
        }

        // Mover al enemigo en la dirección determinada
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

    void Flip()
    {
        // Voltear la orientación del sprite del enemigo
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}