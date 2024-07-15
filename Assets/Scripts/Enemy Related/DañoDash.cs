using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoDash : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2d;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DashAttack"))
        {
            // daño para el enemigo
            // ejecutar animacion daño
            // sonido
            //destruir al enemigo
            animator.Play("dead");
            rb2d.isKinematic = true;
            rb2d.velocity = Vector2.zero;
        }
    }
}
