using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneChange01 : MonoBehaviour
{
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cambio")
        {
            int actualScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(actualScene + 1);
        }
    }

   

}



