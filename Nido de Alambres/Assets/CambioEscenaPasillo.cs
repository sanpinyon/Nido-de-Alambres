using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaPasillo : MonoBehaviour
{
    private bool estaColisionando = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (estaColisionando && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Recreo");
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaColisionando = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaColisionando = false;
        }
    }
}
