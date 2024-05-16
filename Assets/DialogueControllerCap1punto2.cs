using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DialogueControllerCap1punto2 : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public int Index = 0;
    public float DialogueSpeed;
    public Image Esc1;
    public Image Esc2;
    public Image Esc3;
    public Image Esc4;
    private bool isWriting = false;
    public AudioSource sonidoAmbiente;
    public VideoPlayer cinematicaCalambre;

    void Start()
    {
        Esc1.enabled = true;
        Esc2.enabled = false;
        Esc3.enabled = false;
        Esc4.enabled = false;
        cinematicaCalambre.gameObject.SetActive(false);
        DisplayNextSentence();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isWriting)
            {
                DisplayNextSentence();
                CambioDialogo();
            }

            else
            {
                StopAllCoroutines();
                DialogueText.text = Sentences[Index -1];
                isWriting = false;
            }
        }
    }

    public void DisplayNextSentence()
    {
        if (Index < Sentences.Length)
        {
            CambioDialogo();
            StartCoroutine(WriteSentence(Sentences[Index]));
        }
        else
        {
            Debug.Log("No hay más diálogos.");
            DialogueText.enabled = false;
            sonidoAmbiente.Stop(); // Detener la reproducción de la música de fondo
            cinematicaCalambre.gameObject.SetActive(true); // Activar el video
            cinematicaCalambre.Play();
        }
        Index++;
    }

    IEnumerator WriteSentence(string sentence)
    {
        isWriting = true;
        DialogueText.text = "";

        foreach (char Character in sentence.ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }

        isWriting = false;
    }

    void CambioDialogo()
    {
        if (Index == 0 || Index == 1 || Index == 2)
        {
            Esc1.enabled = true;
            Esc2.enabled = false;
            Esc3.enabled = false;
            Esc4.enabled = false;
            cinematicaCalambre.gameObject.SetActive(false);
        }
        else if (Index == 3 || Index == 4 || Index == 5 || Index == 6 || Index == 7 || Index == 12 || Index == 13)
        {
            Esc1.enabled = false;
            Esc2.enabled = true;
            Esc3.enabled = false;
            Esc4.enabled = false;
            cinematicaCalambre.gameObject.SetActive(false);
        }
        else if (Index == 8 || Index == 9 || Index == 10 || Index == 11)
        {
            Esc1.enabled = false;
            Esc2.enabled = false;
            Esc3.enabled = true;
            Esc4.enabled = false;
            cinematicaCalambre.gameObject.SetActive(false);
        }
        else if (Index >= 14 && Index <= 20) // Corregir condición de la última imagen
        {
            Esc1.enabled = false;
            Esc2.enabled = false;
            Esc3.enabled = false;
            Esc4.enabled = true;
            cinematicaCalambre.gameObject.SetActive(false);
        }
        else
        {
            DialogueText.enabled = false;
            sonidoAmbiente.Stop(); // Detener la reproducción de la música de fondo
            cinematicaCalambre.gameObject.SetActive(true); // Activar el video
            cinematicaCalambre.loopPointReached += EndReached;
            cinematicaCalambre.Play();
        }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // Cuando se alcanza el final del video, cargar la escena "Clase"
        SceneManager.LoadScene("Clase");
    }
    }
}

