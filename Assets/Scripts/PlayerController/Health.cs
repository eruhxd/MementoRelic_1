using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int PuntosTotales { get; private set; }

    private int vidas = 1;
    [SerializeField] float loadEndIn;
    [SerializeField] Animator anim;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un GameManager en escena.");
        }
    }

    public void PerderVida()
    {
        vidas -= 1;

        if (vidas == 0)
        {
            anim.SetBool("Died", true );
            Invoke("EndLevel", loadEndIn);
        }
        
    }

    public void EndLevel()
    {
        // Reiniciamos el nivel.
        SceneManager.LoadScene(0);

    }
}