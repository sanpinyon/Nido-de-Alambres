using UnityEngine;

public class ControladorPasillo : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        // Encuentra el objeto GameManager en la escena
        gameManager = FindObjectOfType<GameManager>();

        // Carga y reproduce la música desde el tiempo guardado para la primera canción (índice 0)
        gameManager.CargarYReproducirMusica(0);
    }

}
