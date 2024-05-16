using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DialogueControllerSonrisa : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public int Index = 0;
    public float DialogueSpeed;
    public Image Sonrisa1;
    public Image Sonrisa2;
    public Image Sonrisa3;
    public Image Sonrisa4;
    public Image Sonrisa5;
    public Image Sonrisa6;
    public Image Pulsera;
    public Image Dialogo;

    private bool isWriting = false;
    public VideoPlayer cinematicaLibroSonr;
    void Start()
    {
        Sonrisa1.enabled = true;
        Sonrisa2.enabled = false;
        Sonrisa3.enabled = false;
        Sonrisa4.enabled = false;
        Sonrisa5.enabled = false;
        Sonrisa6.enabled = false;
        Pulsera.enabled = false;
        cinematicaLibroSonr.gameObject.SetActive(false);
        DisplayNextSentence();
        
    }

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
            cinematicaLibroSonr.gameObject.SetActive(true);
            cinematicaLibroSonr.Play();
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
        if (Index == 0 || Index == 1 || Index == 2 || Index == 3)
        {
            Sonrisa1.enabled = true;
            Sonrisa2.enabled = false;
            Sonrisa3.enabled = false;
            Sonrisa4.enabled = false;
            Sonrisa5.enabled = false;
            Sonrisa6.enabled = false;
            cinematicaLibroSonr.gameObject.SetActive(false);
        }
        else if (Index == 4 || Index == 5 || Index == 6)
        {
            Sonrisa1.enabled = false;
            Sonrisa2.enabled = true;
            Sonrisa3.enabled = false;
            Sonrisa4.enabled = false;
            Sonrisa5.enabled = false;
            Sonrisa6.enabled = false;
            cinematicaLibroSonr.gameObject.SetActive(false);
        }
        else if (Index == 7 || Index == 8)
        {
            Sonrisa1.enabled = false;
            Sonrisa2.enabled = false;
            Sonrisa3.enabled = true;
            Sonrisa4.enabled = false;
            Sonrisa5.enabled = false;
            Sonrisa6.enabled = false;
            cinematicaLibroSonr.gameObject.SetActive(false);
        }
        else if (Index == 9 || Index == 10 || Index == 11)
        {
            Sonrisa1.enabled = false;
            Sonrisa2.enabled = false;
            Sonrisa3.enabled = false;
            Sonrisa4.enabled = true;
            Sonrisa5.enabled = false;
            Sonrisa6.enabled = false;
            cinematicaLibroSonr.gameObject.SetActive(false);
        }

        else if (Index == 12 || Index == 13 || Index == 14 || Index == 15  || Index == 16)
        {
            Sonrisa1.enabled = false;
            Sonrisa2.enabled = false;
            Sonrisa3.enabled = false;
            Sonrisa4.enabled = false;
            Sonrisa5.enabled = true;
            Sonrisa6.enabled = false;
            cinematicaLibroSonr.gameObject.SetActive(false);
            if (Index == 14)
            {
                Pulsera.enabled = true;
            }
            else
            {
                Pulsera.enabled = false;
            }
        }

        else if (Index == 17  || Index == 18 || Index == 19)
        {
            Sonrisa1.enabled = false;
            Sonrisa2.enabled = false;
            Sonrisa3.enabled = false;
            Sonrisa4.enabled = false;
            Sonrisa5.enabled = false;
            Sonrisa6.enabled = true;
            cinematicaLibroSonr.gameObject.SetActive(false);
        }

        else
        {
            DialogueText.enabled = false;
            cinematicaLibroSonr.gameObject.SetActive(true);
            cinematicaLibroSonr.loopPointReached += EndReached;
            cinematicaLibroSonr.Play();
        }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Principio");
    }
    }
        
}
