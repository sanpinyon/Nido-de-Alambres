using UnityEngine;

public class SeguirPersonaje : MonoBehaviour
{
    public Transform personaje; // Referencia al objeto del personaje

    void Update()
    {
        if (personaje != null)
        {
            // Obtener la posición del personaje y asignarla a la cámara
            transform.position = personaje.position;
        }
    }
}
