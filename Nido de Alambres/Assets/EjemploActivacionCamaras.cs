using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploActivacionCamaras : MonoBehaviour
{
    public ControladorCamaras controladorCamaras;

    void Start()
    {
        // Activar la cámara número 2 al iniciar el nivel
        controladorCamaras.ActivarCamara(2);
    }
}

