using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DialogueControllerCap4 : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public int Index = 0;
    public float DialogueSpeed;
    public Image Caida1;
    public Image Caida2;
    public Image Caida3;
    public Image Caida4;
    public Image Caida5;
    public Image Caida6;
    public Image Caida7;
    public Image Caida8;
    public Image Caida9;
    public Image Caida10;
    public Image FondoTexto;
    private bool isWriting = false;
    public VideoPlayer cinematicaCaida;
    public AudioSource Cap41;
    public AudioSource Cap42;

    void Start()
    {
        Caida1.enabled = true;
        Caida2.enabled = false;
        Caida3.enabled = false;
        Caida4.enabled = false;
        Caida5.enabled = false;
        Caida6.enabled = false;
        Caida7.enabled = false;
        Caida8.enabled = false;
        Caida9.enabled = false;
        Caida10.enabled = false;
        FondoTexto.enabled = true;
        cinematicaCaida.gameObject.SetActive(false);
        Cap41.Play();
        Cap42.Stop();
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

        if (Index == 11)
        {
            Cap41.Stop();
            Cap42.Play();
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
            cinematicaCaida.gameObject.SetActive(true);
            cinematicaCaida.Play();
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
            Caida1.enabled = true;
            Caida2.enabled = false;
            Caida3.enabled = false;
            Caida4.enabled = false;
            Caida5.enabled = false;
            Caida6.enabled = false;
            Caida7.enabled = false;
            Caida8.enabled = false;
            Caida9.enabled = false;
            Caida10.enabled = false;
            cinematicaCaida.gameObject.SetActive(false);
        }
        else if (Index == 4)
        {
            Caida1.enabled = false;
            Caida2.enabled = true;
            Caida3.enabled = false;
            Caida4.enabled = false;
            Caida5.enabled = false;
            Caida6.enabled = false;
            Caida7.enabled = false;
            Caida8.enabled = false;
            Caida9.enabled = false;
            Caida10.enabled = false;
            cinematicaCaida.gameObject.SetActive(false);
        }
        else if (Index == 5)
        {
            Caida1.enabled = false;
            Caida2.enabled = false;
            Caida3.enabled = true;
            Caida4.enabled = false;
            Caida5.enabled = false;
            Caida6.enabled = false;
            Caida7.enabled = false;
            Caida8.enabled = false;
            Caida9.enabled = false;
            Caida10.enabled = false;
            cinematicaCaida.gameObject.SetActive(false);
        }
        else if (Index == 6)
        {
            Caida1.enabled = false;
            Caida2.enabled = false;
            Caida3.enabled = false;
            Caida4.enabled = true;
            Caida5.enabled = false;
            Caida6.enabled = false;
            Caida7.enabled = false;
            Caida8.enabled = false;
            Caida9.enabled = false;
            Caida10.enabled = false;
            cinematicaCaida.gameObject.SetActive(false);

        }

        else if (Index == 7)
        {
            Caida1.enabled = false;
            Caida2.enabled = false;
            Caida3.enabled = false;
            Caida4.enabled = false;
            Caida5.enabled = true;
            Caida6.enabled = false;
            Caida7.enabled = false;
            Caida8.enabled = false;
            Caida9.enabled = false;
            Caida10.enabled = false;
            cinematicaCaida.gameObject.SetActive(false);

        }

        else if (Index == 8 || Index == 9 || Index == 10)
        {
            Caida1.enabled = false;
            Caida2.enabled = false;
            Caida3.enabled = false;
            Caida4.enabled = false;
            Caida5.enabled = false;
            Caida6.enabled = true;
            Caida7.enabled = false;
            Caida8.enabled = false;
            Caida9.enabled = false;
            Caida10.enabled = false;
            cinematicaCaida.gameObject.SetActive(false);

        }

        else if (Index == 11)
        {
            Caida1.enabled = false;
            Caida2.enabled = false;
            Caida3.enabled = false;
            Caida4.enabled = false;
            Caida5.enabled = false;
            Caida6.enabled = false;
            Caida7.enabled = true;
            Caida8.enabled = false;
            Caida9.enabled = false;
            Caida10.enabled = false;
            cinematicaCaida.gameObject.SetActive(false);

        }

        else if (Index == 12 || Index == 13)
        {
            Caida1.enabled = false;
            Caida2.enabled = false;
            Caida3.enabled = false;
            Caida4.enabled = false;
            Caida5.enabled = false;
            Caida6.enabled = false;
            Caida7.enabled = false;
            Caida8.enabled = true;
            Caida9.enabled = false;
            Caida10.enabled = false;
            cinematicaCaida.gameObject.SetActive(false);

        }

        else if (Index == 14 || Index == 15)
        {
            Caida1.enabled = false;
            Caida2.enabled = false;
            Caida3.enabled = false;
            Caida4.enabled = false;
            Caida5.enabled = false;
            Caida6.enabled = false;
            Caida7.enabled = false;
            Caida8.enabled = false;
            Caida9.enabled = true;
            Caida10.enabled = false;
            cinematicaCaida.gameObject.SetActive(false);

        }

        else if (Index == 16 || Index == 17 || Index == 18 || Index == 19 || Index == 20 || Index == 21)
        {
            Caida1.enabled = false;
            Caida2.enabled = false;
            Caida3.enabled = false;
            Caida4.enabled = false;
            Caida5.enabled = false;
            Caida6.enabled = false;
            Caida7.enabled = false;
            Caida8.enabled = false;
            Caida9.enabled = false;
            Caida10.enabled = true;
            cinematicaCaida.gameObject.SetActive(false);

        }

        else
        {
            DialogueText.enabled = false;
            FondoTexto.enabled = false;
            cinematicaCaida.gameObject.SetActive(true); // Activar el video
            cinematicaCaida.loopPointReached += EndReached;
            cinematicaCaida.Play();
        }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // Cuando se alcanza el final del video, cargar la escena "Clase"
        SceneManager.LoadScene("Solo");
    }
    }
}