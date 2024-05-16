using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SoloCambioEscena : MonoBehaviour
{
    public VideoPlayer cinematicaSolo;

    void Start()
    {
       cinematicaSolo.Play();  
       cinematicaSolo.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // Cuando se alcanza el final del video, cargar la escena "MenuInicio"
        SceneManager.LoadScene("Refugio");
    }
}

