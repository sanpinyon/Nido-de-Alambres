using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DialogueControllerCap3 : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public int Index = 0;
    public float DialogueSpeed;
    public Image Ciclo1;
    public Image Ciclo2;
    public Image Ciclo3;
    public Image Ciclo4;
    public Image Ciclo5;
    public Image Ciclo6;
    public Image Ciclo7;
    public Image Ciclo8;
    public Image Ciclo9;
    public Image Ciclo10;
    public Image FondoTexto;
    private bool isWriting = false;
    public VideoPlayer cinematicaCiclo;

    void Start()
    {
        Ciclo1.enabled = true;
        Ciclo2.enabled = false;
        Ciclo3.enabled = false;
        Ciclo4.enabled = false;
        Ciclo5.enabled = false;
        Ciclo6.enabled = false;
        Ciclo7.enabled = false;
        Ciclo8.enabled = false;
        Ciclo9.enabled = false;
        Ciclo10.enabled = false;
        FondoTexto.enabled = true;
        cinematicaCiclo.gameObject.SetActive(false);
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
            cinematicaCiclo.gameObject.SetActive(true);
            cinematicaCiclo.Play();
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
        if (Index == 0 || Index == 1)
        {
            Ciclo1.enabled = true;
            Ciclo2.enabled = false;
            Ciclo3.enabled = false;
            Ciclo4.enabled = false;
            Ciclo5.enabled = false;
            Ciclo6.enabled = false;
            Ciclo7.enabled = false;
            Ciclo8.enabled = false;
            Ciclo9.enabled = false;
            Ciclo10.enabled = false;
            cinematicaCiclo.gameObject.SetActive(false);
        }
        else if (Index == 2)
        {
            Ciclo1.enabled = false;
            Ciclo2.enabled = true;
            Ciclo3.enabled = false;
            Ciclo4.enabled = false;
            Ciclo5.enabled = false;
            Ciclo6.enabled = false;
            Ciclo7.enabled = false;
            Ciclo8.enabled = false;
            Ciclo9.enabled = false;
            Ciclo10.enabled = false;
            cinematicaCiclo.gameObject.SetActive(false);
        }
        else if (Index == 3 || Index == 4)
        {
            Ciclo1.enabled = false;
            Ciclo2.enabled = false;
            Ciclo3.enabled = true;
            Ciclo4.enabled = false;
            Ciclo5.enabled = false;
            Ciclo6.enabled = false;
            Ciclo7.enabled = false;
            Ciclo8.enabled = false;
            Ciclo9.enabled = false;
            Ciclo10.enabled = false;
            cinematicaCiclo.gameObject.SetActive(false);
        }
        else if (Index == 5 || Index == 6)
        {
            Ciclo1.enabled = false;
            Ciclo2.enabled = false;
            Ciclo3.enabled = false;
            Ciclo4.enabled = true;
            Ciclo5.enabled = false;
            Ciclo6.enabled = false;
            Ciclo7.enabled = false;
            Ciclo8.enabled = false;
            Ciclo9.enabled = false;
            Ciclo10.enabled = false;
            cinematicaCiclo.gameObject.SetActive(false);

        }

        else if (Index == 7)
        {
            Ciclo1.enabled = false;
            Ciclo2.enabled = false;
            Ciclo3.enabled = false;
            Ciclo4.enabled = false;
            Ciclo5.enabled = true;
            Ciclo6.enabled = false;
            Ciclo7.enabled = false;
            Ciclo8.enabled = false;
            Ciclo9.enabled = false;
            Ciclo10.enabled = false;
            cinematicaCiclo.gameObject.SetActive(false);

        }

        else if (Index == 8)
        {
            Ciclo1.enabled = false;
            Ciclo2.enabled = false;
            Ciclo3.enabled = false;
            Ciclo4.enabled = false;
            Ciclo5.enabled = false;
            Ciclo6.enabled = true;
            Ciclo7.enabled = false;
            Ciclo8.enabled = false;
            Ciclo9.enabled = false;
            Ciclo10.enabled = false;
            cinematicaCiclo.gameObject.SetActive(false);

        }

        else if (Index == 9 || Index == 10)
        {
            Ciclo1.enabled = false;
            Ciclo2.enabled = false;
            Ciclo3.enabled = false;
            Ciclo4.enabled = false;
            Ciclo5.enabled = false;
            Ciclo6.enabled = false;
            Ciclo7.enabled = true;
            Ciclo8.enabled = false;
            Ciclo9.enabled = false;
            Ciclo10.enabled = false;
            cinematicaCiclo.gameObject.SetActive(false);

        }

        else if (Index == 11)
        {
            Ciclo1.enabled = false;
            Ciclo2.enabled = false;
            Ciclo3.enabled = false;
            Ciclo4.enabled = false;
            Ciclo5.enabled = false;
            Ciclo6.enabled = false;
            Ciclo7.enabled = false;
            Ciclo8.enabled = true;
            Ciclo9.enabled = false;
            Ciclo10.enabled = false;
            cinematicaCiclo.gameObject.SetActive(false);

        }

        else if (Index == 12 || Index == 13)
        {
            Ciclo1.enabled = false;
            Ciclo2.enabled = false;
            Ciclo3.enabled = false;
            Ciclo4.enabled = false;
            Ciclo5.enabled = false;
            Ciclo6.enabled = false;
            Ciclo7.enabled = false;
            Ciclo8.enabled = false;
            Ciclo9.enabled = true;
            Ciclo10.enabled = false;
            cinematicaCiclo.gameObject.SetActive(false);

        }

        else if (Index == 14 || Index == 15)
        {
            Ciclo1.enabled = false;
            Ciclo2.enabled = false;
            Ciclo3.enabled = false;
            Ciclo4.enabled = false;
            Ciclo5.enabled = false;
            Ciclo6.enabled = false;
            Ciclo7.enabled = false;
            Ciclo8.enabled = false;
            Ciclo9.enabled = false;
            Ciclo10.enabled = true;
            cinematicaCiclo.gameObject.SetActive(false);

        }

        else
        {
            DialogueText.enabled = false;
            FondoTexto.enabled = false;
            // sonidoAmbiente.Stop(); // Detener la reproducción de la música de fondo
            cinematicaCiclo.gameObject.SetActive(true); // Activar el video
            cinematicaCiclo.loopPointReached += EndReached;
            cinematicaCiclo.Play();
        }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // Cuando se alcanza el final del video, cargar la escena "Clase"
        SceneManager.LoadScene("Caida");
    }
    }
}
