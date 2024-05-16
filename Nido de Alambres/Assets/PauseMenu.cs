using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static bool GameIsPaused = false;
    public OcultarRaton ocultarRatonScript;

    private VideoPlayer[] videoPlayers;

    void Start()
    {
        videoPlayers = FindObjectsOfType<VideoPlayer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Continuar();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        pauseMenu.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
        ocultarRatonScript.MostrarRaton();

        // Pausar todos los videos
        foreach (VideoPlayer player in videoPlayers)
        {
            if (player.isPlaying)
            {
                player.Pause();
            }
        }
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuInicio");
    }

    public void Continuar()
    {
        pauseMenu.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        ocultarRatonScript.EsconderRaton();

        // Reanudar todos los videos
        foreach (VideoPlayer player in videoPlayers)
        {
            if (player.isPaused)
            {
                player.Play();
            }
        }
    }
}

