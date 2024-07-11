using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnter : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] string tagFilter = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagFilter)) { 
            onTriggerEnter.Invoke();
        }
    }
}
