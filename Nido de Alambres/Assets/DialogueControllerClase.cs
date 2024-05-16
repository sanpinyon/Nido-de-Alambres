using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueControllerClase : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public int Index = 0;
    public float DialogueSpeed;
    public Image DialogoNiño1;
    public Image DialogoNiño2;
    public Image DialogoNiña;
    public Image DialogoLeo;
    public GameObject niño1;
    public GameObject niño2;
    public GameObject niña1;
    public GameObject Leo;
    public GameObject Player;
    public AudioSource alarma;
    public AudioSource sonido;
    public MisionesClase misionesClase;
    public ControladorCamaras controladorCamaras;
    private bool isWriting = false;

    void Start()
    {
        DialogoNiño1.enabled = false;
        DialogoNiño2.enabled = false;
        DialogoNiña.enabled = true;
        DialogoLeo.enabled = false;
        controladorCamaras.ActivarCamara(3);
        Player.SetActive(false);
        niño1.SetActive(true);
        niño2.SetActive(true);
        niña1.SetActive(true);
        Leo.SetActive(true);
        DisplayNextSentence();
        sonido.Play();
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
        if (Index == 10 && alarma != null)
        {
            alarma.Play();
        }
        }
        else
        {
            Debug.Log("No hay más diálogos.");
            DialogueText.enabled = false;
            misionesClase.MostrarMision1();
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
        if (Index == 2 || Index == 4 || Index == 7 || Index == 9)
        {
            DialogoNiño1.enabled = true;
            DialogoNiño2.enabled = false;
            DialogoNiña.enabled = false;
            DialogoLeo.enabled = false;
            controladorCamaras.ActivarCamara(1);
        }
        else if (Index == 3 || Index == 11)
        {
            DialogoNiño1.enabled = false;
            DialogoNiño2.enabled = true;
            DialogoNiña.enabled = false;
            DialogoLeo.enabled = false;
            controladorCamaras.ActivarCamara(2);
        }
        else if (Index == 0 || Index == 1 || Index == 5 || Index == 8 || Index == 10)
        {
            DialogoNiño1.enabled = false;
            DialogoNiño2.enabled = false;
            DialogoNiña.enabled = true;
            DialogoLeo.enabled = false;
            controladorCamaras.ActivarCamara(3);
            niño1.SetActive(true);
            niño2.SetActive(true);
            niña1.SetActive(true);
            Leo.SetActive(true);
            Player.SetActive(false);
        }
        else if (Index == 6 || Index == 12)
        {
            DialogoNiño1.enabled = false;
            DialogoNiño2.enabled = false;
            DialogoNiña.enabled = false;
            DialogoLeo.enabled = true;
            controladorCamaras.ActivarCamara(0);
        }
        else
        {
            DialogoNiño1.enabled = false;
            DialogoNiño2.enabled = false;
            DialogoNiña.enabled = false;
            DialogoLeo.enabled = false;
            controladorCamaras.ActivarCamara(4);
            niño1.SetActive(false);
            niño2.SetActive(false);
            niña1.SetActive(false);
            Leo.SetActive(false);
            Player.SetActive(true);
            sonido.Stop();
        }
    }
}