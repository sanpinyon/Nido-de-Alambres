using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public int Index = 0;
    public float DialogueSpeed;
    private VisibilidadDialogo visibilidadDialogo;

    private MisionesController misionesController;
    public MovimientoPersonaje movimientoPersonaje;

    private bool isWriting = false; // Bandera para controlar si se está escribiendo el diálogo actual

    void Start()
    {
        visibilidadDialogo = GetComponent<VisibilidadDialogo>(); // Obtener la referencia al script VisibilidadDialogo
        misionesController = FindObjectOfType<MisionesController>(); // Buscar el componente MisionesController en la escena
        DisplayNextSentence();
    }


    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                // Verificar si se está escribiendo el diálogo actual antes de permitir pasar al siguiente
                if (!isWriting)
                {
                    DisplayNextSentence();
                }
                
                else
                {
                    StopAllCoroutines();
                    DialogueText.text = Sentences[Index -1];
                    isWriting = false;
                }
            }
    }

    void DisplayNextSentence()
    {
        if (Index < Sentences.Length)
        {
            StartCoroutine(WriteSentence(Sentences[Index]));
            Index++;
        }
        else
        {
            Debug.Log("No hay más diálogos.");
            visibilidadDialogo.HideDialogue(); // Ocultar el diálogo al llegar al final
            if (misionesController != null)
            {
                misionesController.Mision1.enabled = true; // Activar la imagen de la misión
                //movimientoPersonaje.ReanudarMovimiento();
            }
        }
    }

    IEnumerator WriteSentence(string sentence)
    {
        isWriting = true; // Indicar que se está escribiendo el diálogo actual
        DialogueText.text = ""; // Limpiar el texto del diálogo

        foreach (char Character in sentence.ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }

        isWriting = false; // Indicar que se ha completado la escritura del diálogo actual
    }
}

