using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisibilidadDialogoCuento : MonoBehaviour
{
    public Image Dialogo;
    public TextMeshProUGUI Texto;
    public GameObject DialogueController;

    // Función para mostrar el diálogo
    public void ShowDialogue()
    {
        Dialogo.enabled = true; // Hace visible la imagen del diálogo
        Texto.enabled = true; // Hace visible el texto del diálogo
    }

    // Función para ocultar el diálogo
    public void HideDialogue()
    {
        Dialogo.enabled = false; // Oculta la imagen del diálogo
        Texto.enabled = false; // Oculta el texto del diálogo
    }

    void Start()
    {
        ShowDialogue();
    }
}