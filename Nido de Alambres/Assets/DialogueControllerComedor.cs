using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueControllerComedor : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public int Index = 0;
    public float DialogueSpeed;
    public Image DialogoYaya;
    public Image DialogoNiño;
    public Image PensamientoYaya;

    public MisionesComedor misionesComedor;

    private bool isWriting = false;

    private ActivadorDialogo activarDialogo;
    public MovimientoPersonaje movimientoPersonaje;
    public GameObject QuietoParao;

    void Start()
    {
        gameObject.SetActive(false); // Desactivar el GameObject que contiene este script
        DialogoNiño.enabled = false;
        DialogoYaya.enabled = false;
        PensamientoYaya.enabled = false;
    }

    void Update()
    {
        // DialogoNiño.enabled = true;
        // DialogoYaya.enabled = true;
        // DialogueText.enabled = true;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Verificar si se está escribiendo el diálogo actual antes de permitir pasar al siguiente
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
            misionesComedor.MostrarMision2();
            //activarDialogo.enabled = false;
            movimientoPersonaje.ReanudarMovimiento();
            QuietoParao.SetActive(false);
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
        if (Index == 1 || Index == 3 || Index == 6 || Index == 7 || Index == 9)
        {
            DialogoYaya.enabled = true;
            DialogoNiño.enabled = false;
            PensamientoYaya.enabled = false;
        }
        else if (Index == 2 || Index == 4 || Index == 8 || Index == 10)
        {
            DialogoYaya.enabled = false;
            DialogoNiño.enabled = true;
            PensamientoYaya.enabled = false;
        }
        else if (Index == 5)
        {
            DialogoYaya.enabled = false;
            DialogoNiño.enabled = false;
            PensamientoYaya.enabled = true;
        }
        else
        {
            DialogoYaya.enabled = false;
            DialogoNiño.enabled = false;
            PensamientoYaya.enabled = false;
        }
    }
}