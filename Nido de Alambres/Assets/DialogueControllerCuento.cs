using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;

public class DialogueControllerCuento : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;
    private VisibilidadDialogo visibilidadDialogo;
    private bool isWriting = false; // Bandera para controlar si se está escribiendo el diálogo actual

    public ControladorImagenes controladorImagenes; // Referencia al script que controla el paso entre imágenes
    public VideoPlayer videoPlayer; // Referencia al reproductor de video
    public AudioSource musicaFondo; // Referencia al componente AudioSource de la música de fondo

    private bool ultimoDialogo = false;
    private bool ultimoImagen = false;

    void Start()
    {
        visibilidadDialogo = GetComponent<VisibilidadDialogo>(); // Obtener la referencia al script VisibilidadDialogo
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
        }
        else
        {
            Debug.Log("No hay más diálogos.");
            ultimoDialogo = true; // Indicar que es el último diálogo

            //visibilidadDialogo.HideDialogue(); // Ocultar el diálogo al llegar al final
            controladorImagenes.MostrarSiguienteImagen();
        }

        // Verificar si es la última imagen
        if (Index == Sentences.Length - 1 && ultimoDialogo)
        {
            ultimoImagen = true; // Indicar que es la última imagen
        }

        // Verificar si es la última imagen y el último diálogo
        if (ultimoDialogo && ultimoImagen)
        {
            ReproducirVideo(); // Reproducir el video después de mostrar la última imagen y el último diálogo
        }

        Index++; // Incrementar el índice al completar el diálogo actual
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

    void ReproducirVideo()
    {
        musicaFondo.Stop();
        videoPlayer.gameObject.SetActive(true);
        videoPlayer.Play();
    }
}
