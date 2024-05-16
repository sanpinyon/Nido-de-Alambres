// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class VisibilidadDialogoComedor : MonoBehaviour
// {

//     public GameObject DialogueControllerComedor;

//     // Función para mostrar el diálogo
//     public void ShowDialogue()
//     {
//         Dialogo.enabled = true; // Hace visible la imagen del diálogo
//         Texto.enabled = true; // Hace visible el texto del diálogo
//     }

//     // Función para ocultar el diálogo
//     public void HideDialogue()
//     {
//         Dialogo.enabled = false; // Oculta la imagen del diálogo
//         Texto.enabled = false; // Oculta el texto del diálogo
//     }

//     void Start()
//     {
//         HideDialogue();
//     }

//     void OnTriggerEnter(Collider other)
//     {
//         // Verificar si el objeto que ha colisionado tiene la etiqueta "Player"
//         if (other.CompareTag("Player"))
//         {
//             ShowDialogue();
//         }
//     }
// }
