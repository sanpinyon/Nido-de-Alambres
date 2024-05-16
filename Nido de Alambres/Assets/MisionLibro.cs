using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisionLibro : MonoBehaviour
{
    private bool estaColisionando = false;
    public Image Libro;

    public MisionesComedor misionesComedor;
    
    public ComportamientoAbuela comportamientoAbuela;

    public CambioCap1 cambioCap1;

    public bool haSidoActivado = false;
    void Start()
    {
        Libro.enabled = false;
    }

    void Update()
    {
        if (estaColisionando && Input.GetKeyDown(KeyCode.E))
        {
            Libro.enabled = true;
            misionesComedor.MostrarMision3();
            comportamientoAbuela.movimientoActivo = true;
            cambioCap1.ActivarCambioEscena();
            Debug.Log("El valor de miVariableBooleana es: " + cambioCap1.puedeCambiarEscena);
            haSidoActivado = true;
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

    private void seHaActivado()
    {
        if (haSidoActivado = true)
        {
            estaColisionando = false;
        }  
    }
}
