using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CambioCap1 : MonoBehaviour
{
    public string nombreDeLaEscenaACargar = "Capitulo1";
    private bool estaColisionando = false;
    public bool puedeCambiarEscena = false;
    public VideoPlayer videoPlayer;

    void Start()
    {
        DesactivarCambioEscena();

        // Suscribe el método al evento loopPointReached del VideoPlayer
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += VideoTerminado;
        }
    }

    private void Update()
    {
        if (estaColisionando && PuedeCambiarEscena() && Input.GetKeyDown(KeyCode.E))
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

    public void ActivarCambioEscena()
    {
        puedeCambiarEscena = true;
    }

    public void DesactivarCambioEscena()
    {
        puedeCambiarEscena = false;
    }

    public bool PuedeCambiarEscena()
    {
        return puedeCambiarEscena;
    }

    // Método que se llamará cuando el video termine
    void VideoTerminado(UnityEngine.Video.VideoPlayer vp)
    {
        // Cambiar a la siguiente escena cuando el video termine
        SceneManager.LoadScene(nombreDeLaEscenaACargar);
    }
}