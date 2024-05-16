using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EscenasController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Asigna el componente VideoPlayer de tu escena Transicion en el Inspector
    private int indiceEscenaActual = 0;
    public List<string> escenasDestino = new List<string> {"Calle", "Comedor", "Capitulo1", "Clase" };

    void Start()
    {
        // Obtener el índice de la escena actual de PlayerPrefs
        if (PlayerPrefs.HasKey("IndiceEscenaActual"))
        {
            indiceEscenaActual = PlayerPrefs.GetInt("IndiceEscenaActual");
        }

        // Asegúrate de que el VideoPlayer esté asignado en el Inspector
        if (videoPlayer != null)
        {
            // Suscribe el método al evento loopPointReached del VideoPlayer
            videoPlayer.loopPointReached += VideoTerminado;
        }
        
        // Cargar la primera escena
        SceneManager.LoadScene(escenasDestino[indiceEscenaActual]);
    }

    // Método que se llamará cuando el video termine
    void VideoTerminado(UnityEngine.Video.VideoPlayer vp)
    {
        if (indiceEscenaActual < escenasDestino.Count - 1)
        {
            // Incrementa el índice antes de cargar la siguiente escena
            indiceEscenaActual++;

            // Guardar el índice de la escena actual en PlayerPrefs
            PlayerPrefs.SetInt("IndiceEscenaActual", indiceEscenaActual);

            // Carga la siguiente escena en la lista
            SceneManager.LoadScene(escenasDestino[indiceEscenaActual]);
        }
    }
}


