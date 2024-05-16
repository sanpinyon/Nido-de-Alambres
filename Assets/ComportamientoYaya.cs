using UnityEngine;

public class ComportamientoAbuela : MonoBehaviour
{
    public Transform puntoDestino; // Referencia al punto de destino
    public Quaternion rotacionDestino; // Rotación deseada al llegar al punto de destino
    public float velocidadMovimiento = 2f; // Velocidad de movimiento de la abuela
    public float velocidadRotacion = 5f; // Velocidad de rotación de la abuela
    public Animator animatorAbuela; // Referencia al componente Animator de la abuela

    public bool movimientoActivo = false;

    void Start()
    {
        movimientoActivo = false;
    }

    // Método para iniciar el movimiento de la abuela
    public void IniciarMovimiento()
    {
        movimientoActivo = true;
    }

    void Update()
    {
        if (movimientoActivo)
        {
            // Mover la abuela hacia el punto de destino
            transform.position = Vector3.MoveTowards(transform.position, puntoDestino.position, velocidadMovimiento * Time.deltaTime);

            // Rotar la abuela hacia la rotación deseada
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionDestino, velocidadRotacion * Time.deltaTime);
            

            // Si la abuela ha llegado al punto de destino
            if (transform.position == puntoDestino.position)
            {
                // Desactivar el movimiento
                movimientoActivo = false;

                // Activar la animación de sentarse
                animatorAbuela.SetTrigger("Sentarse");
                animatorAbuela.SetTrigger("Yaya_Sentarse");
            }
        }
    }
}


