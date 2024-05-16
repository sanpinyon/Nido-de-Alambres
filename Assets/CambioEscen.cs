using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Puerta : MonoBehaviour
{
    public string nombreDeLaEscenaACargarDespuesDeTransicion = "Comedor";
    public VideoPlayer videoPlayer; // Asigna el VideoPlayer en el Inspector
    private bool estaColisionando = false;

    private void Update()
    {
        // Si el jugador está cerca, colisionando y presiona la tecla "E"
        if (estaColisionando && Input.GetKeyDown(KeyCode.E))
        {
            // Reproduce el video de transición
            if (videoPlayer != null)
            {
                videoPlayer.Play();
            }
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

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += VideoTerminado;
        }
    }

    void VideoTerminado(VideoPlayer vp)
    {
        SceneManager.LoadScene(nombreDeLaEscenaACargarDespuesDeTransicion);
    }
}


