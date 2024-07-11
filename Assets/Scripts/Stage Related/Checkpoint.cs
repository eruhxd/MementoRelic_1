using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Animator animator;
    public CheckpointManager cpm;
    bool yaPasoPorAca;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(!yaPasoPorAca)
            {
                animator.Play("cp");
                cpm.lastPlayerPosition.valor = collision.transform.position;
                yaPasoPorAca = true;
            }

        }
    }
}
