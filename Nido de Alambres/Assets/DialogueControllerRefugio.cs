using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DialogueControllerRefugio : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public int Index = 0;
    public float DialogueSpeed;
    public Image Refugio1;
    public Image Refugio2;
    public Image Refugio3;
    public Image Refugio4;
    public Image Refugio5;
    public Image Refugio6;
    public Image Refugio7;
    public Image Refugio8;
    public Image Refugio9;
    public AudioSource MusicaFinal;

    public Image Pergamino;
    private bool isWriting = false;
    public VideoPlayer cinematicaLibro;

    void Start()
    {
        Refugio1.enabled = true;
        Refugio2.enabled = false;
        Refugio3.enabled = false;
        Refugio4.enabled = false;
        Refugio5.enabled = false;
        Refugio6.enabled = false;
        Refugio7.enabled = false;
        Refugio8.enabled = false;
        Refugio9.enabled = false;
        cinematicaLibro.gameObject.SetActive(false);
        DisplayNextSentence();
        MusicaFinal.Play();
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
            cinematicaLibro.gameObject.SetActive(true);
            cinematicaLibro.Play();
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
            Refugio1.enabled = true;
            Refugio2.enabled = false;
            Refugio3.enabled = false;
            Refugio4.enabled = false;
            Refugio5.enabled = false;
            Refugio6.enabled = false;
            Refugio7.enabled = false;
            Refugio8.enabled = false;
            Refugio9.enabled = false;
            cinematicaLibro.gameObject.SetActive(false);
        }
        else if (Index == 2 || Index == 3 || Index == 4)
        {
            Refugio1.enabled = false;
            Refugio2.enabled = true;
            Refugio3.enabled = false;
            Refugio4.enabled = false;
            Refugio5.enabled = false;
            Refugio6.enabled = false;
            Refugio7.enabled = false;
            Refugio8.enabled = false;
            Refugio9.enabled = false;
            cinematicaLibro.gameObject.SetActive(false);
        }
        else if (Index == 5 || Index == 6 || Index == 7 || Index == 8 || Index == 9 || Index == 10)
        {
            Refugio1.enabled = false;
            Refugio2.enabled = false;
            Refugio3.enabled = true;
            Refugio4.enabled = false;
            Refugio5.enabled = false;
            Refugio6.enabled = false;
            Refugio7.enabled = false;
            Refugio8.enabled = false;
            Refugio9.enabled = false;
            cinematicaLibro.gameObject.SetActive(false);
        }
        else if (Index == 11)
        {
            Refugio1.enabled = false;
            Refugio2.enabled = false;
            Refugio3.enabled = false;
            Refugio4.enabled = true;
            Refugio5.enabled = false;
            Refugio6.enabled = false;
            Refugio7.enabled = false;
            Refugio8.enabled = false;
            Refugio9.enabled = false;
            cinematicaLibro.gameObject.SetActive(false);
        }

        else if (Index == 12 || Index == 13)
        {
            Refugio1.enabled = false;
            Refugio2.enabled = false;
            Refugio3.enabled = false;
            Refugio4.enabled = false;
            Refugio5.enabled = true;
            Refugio6.enabled = false;
            Refugio7.enabled = false;
            Refugio8.enabled = false;
            Refugio9.enabled = false;
            cinematicaLibro.gameObject.SetActive(false);
        }

        else if (Index == 14 || Index == 15  || Index == 16  || Index == 17  || Index == 18 || Index == 19)
        {
            Refugio1.enabled = false;
            Refugio2.enabled = false;
            Refugio3.enabled = false;
            Refugio4.enabled = false;
            Refugio5.enabled = false;
            Refugio6.enabled = true;
            Refugio7.enabled = false;
            Refugio8.enabled = false;
            Refugio9.enabled = false;
            cinematicaLibro.gameObject.SetActive(false);
        }

        else if (Index == 20  || Index == 21)
        {
            Refugio1.enabled = false;
            Refugio2.enabled = false;
            Refugio3.enabled = false;
            Refugio4.enabled = false;
            Refugio5.enabled = false;
            Refugio6.enabled = false;
            Refugio7.enabled = true;
            Refugio8.enabled = false;
            Refugio9.enabled = false;
            cinematicaLibro.gameObject.SetActive(false);
        }

        else if (Index == 22  || Index == 23)
        {
            Refugio1.enabled = false;
            Refugio2.enabled = false;
            Refugio3.enabled = false;
            Refugio4.enabled = false;
            Refugio5.enabled = false;
            Refugio6.enabled = false;
            Refugio7.enabled = false;
            Refugio8.enabled = true;
            Refugio9.enabled = false;
            cinematicaLibro.gameObject.SetActive(false);
        }

        else if (Index == 24 || Index == 25 || Index == 26)
        {
            Refugio1.enabled = false;
            Refugio2.enabled = false;
            Refugio3.enabled = false;
            Refugio4.enabled = false;
            Refugio5.enabled = false;
            Refugio6.enabled = false;
            Refugio7.enabled = false;
            Refugio8.enabled = false;
            Refugio9.enabled = true;
            cinematicaLibro.gameObject.SetActive(false);
        }

        else
        {
            DialogueText.enabled = false;
            //sonidoAmbiente.Stop();
            cinematicaLibro.gameObject.SetActive(true);
            cinematicaLibro.loopPointReached += EndReached;
            cinematicaLibro.Play();
        }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Sonrisa");
    }
    }
}
