using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamaras : MonoBehaviour
{
    public Camera[] camaras; // Array que contiene todas las cámaras del nivel

    // Método para activar una cámara específica y desactivar las demás
    public void ActivarCamara(int indiceCamara)
    {
        for (int i = 0; i < camaras.Length; i++)
        {
            if (i == indiceCamara)
            {
                camaras[i].enabled = true; // Activar la cámara en el índice especificado
            }
            else
            {
                camaras[i].enabled = false; // Desactivar las demás cámaras
            }
        }
    }
}
