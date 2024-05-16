using UnityEngine;

public class ActivadorDialogo : MonoBehaviour
{
    public DialogueControllerComedor dialogueControllerComedor; // Referencia al script del diálogo
    private bool haColisionado = false;
    public MovimientoPersonaje movimientoPersonaje;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !haColisionado)
        {
            dialogueControllerComedor.gameObject.SetActive(true); // Activar el GameObject que contiene el script
            dialogueControllerComedor.DisplayNextSentence(); // Mostrar el primer diálogo automáticamente
            dialogueControllerComedor.DialogoYaya.enabled = true;
            movimientoPersonaje.PausarMovimiento();

            haColisionado = true; // Marcar que ha colisionado por primera vez
        }
    }
}