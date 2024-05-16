using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource[] backgroundMusics;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void GuardarTiempoReproduccion(int indexCancion, float tiempo)
    {
        PlayerPrefs.SetFloat("TiempoReproduccion" + indexCancion, tiempo);
        PlayerPrefs.Save();
    }

    public void CargarYReproducirMusica(int indexCancion)
    {
        if (PlayerPrefs.HasKey("TiempoReproduccion" + indexCancion))
        {
            float tiempo = PlayerPrefs.GetFloat("TiempoReproduccion" + indexCancion);
            backgroundMusics[indexCancion].time = tiempo;
            backgroundMusics[indexCancion].Play();
        }
    }

    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
