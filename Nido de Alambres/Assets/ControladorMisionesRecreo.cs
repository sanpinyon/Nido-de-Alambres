using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ControladorMisionesRecreo : MonoBehaviour
{
    public Image mision1;
    public GameObject LeoSentado;
    private bool estaColisionando = false;
    public VideoPlayer cinematicaRecreo;

    void Start()
    {
        LeoSentado.SetActive(false);
        cinematicaRecreo.gameObject.SetActive(false);
    }

    void Update()
    {
        if (estaColisionando && Input.GetKeyDown(KeyCode.E))
        {
            mision1.enabled = false;
            cinematicaRecreo.gameObject.SetActive(true);
            cinematicaRecreo.loopPointReached += EndReached;

            // Detener la música (si está reproduciéndose)
            AudioSource audioSource = FindObjectOfType<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaColisionando = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaColisionando = false;
        }
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Ciclo");
    }
}
