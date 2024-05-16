using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaClase : MonoBehaviour
{
    private bool estaColisionando = false;

    void Start()
    {
        
    }


    void Update()
    {
        if (estaColisionando && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Pasillo");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Está colisionando");
            estaColisionando = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ya no está colisionando");
            estaColisionando = false;
        }
    }
}



