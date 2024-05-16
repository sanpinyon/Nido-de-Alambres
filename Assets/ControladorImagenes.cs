using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ControladorImagenes : MonoBehaviour
{
    public GameObject canvas; // Referencia al canvas que contiene las imágenes
    private int indiceActual = 0; // Índice de la imagen actualmente activa
    public VideoPlayer videoPlayer; // Referencia al reproductor de video
    public AudioSource musicaFondo;

    void Start()
    {
        // Al iniciar, desactiva todas las imágenes excepto la primera
        for (int i = 0; i < canvas.transform.childCount; i++)
        {
            if (i == 0)
            {
                canvas.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                canvas.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        // Desactivar el reproductor de video al inicio
        videoPlayer.gameObject.SetActive(false);

        // Suscribir al evento loopPointReached del VideoPlayer
        videoPlayer.loopPointReached += VideoTerminado;
    }

    void Update()
    {
        // Aquí puedes controlar cómo cambian las imágenes, por ejemplo, al presionar una tecla
        //  if (Input.GetKeyDown(KeyCode.Space))
        //  {
        //      MostrarSiguienteImagen();
        //  }
    }

    public void MostrarSiguienteImagen()
    {
        // Desactiva la imagen actual
        canvas.transform.GetChild(indiceActual).gameObject.SetActive(false);
        
        // Incrementa el índice o vuelve al inicio si llegamos al final de la lista
        indiceActual = (indiceActual + 1) % canvas.transform.childCount;
        
        // Activa la siguiente imagen
        canvas.transform.GetChild(indiceActual).gameObject.SetActive(true);

        // Si se llega a la última imagen, activar el reproductor de video
        if (indiceActual == canvas.transform.childCount - 1)
        {
            musicaFondo.Stop();
            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();
        }
    }

    void VideoTerminado(VideoPlayer vp)
    {
        SceneManager.LoadScene("Capitulo1.2");
    }
}



