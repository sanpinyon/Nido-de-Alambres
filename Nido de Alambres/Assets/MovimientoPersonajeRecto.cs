using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimientoPersonajeRecto : MonoBehaviour {
 
    [Header("Variables Movimiento Del Personaje")]
    public CharacterController controlador;
    public Transform camara;
    public float velocidadDeMovimiento;
    private float rotacionSuave = 0.1f;
    float velocidadRotacionSuave;
    private float velocidadOriginal;


    [Header("Variables Salto y Suelo")]

    public Transform chequeadorDeSuelo;
    public float distanciaAlSuelo;
    public LayerMask mascaraDeSuelo;

    Vector3 velocidad;
    bool estaEnElSuelo;
    public float gravedad = -9.81f;
    public float alturaDelSalto;

    //Animacion
    [Header("Variables de Animación")]
    public Animator animator;


    public string variableMovimiento;
    //public string variableSuelo;



    void Start(){
        controlador = GetComponent<CharacterController>();
        velocidadOriginal = velocidadDeMovimiento;

    }

    void Update(){
        estaEnElSuelo = Physics.CheckSphere(chequeadorDeSuelo.position, distanciaAlSuelo, mascaraDeSuelo);
        if(estaEnElSuelo && velocidad.y <0){
            velocidad.y =-2f;
        }

        // Solo se obtiene la entrada de la tecla W para moverse hacia adelante
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direccion = new Vector3(0f, 0f, vertical).normalized;

        // Solo se ejecuta el movimiento si la dirección tiene una magnitud mayor o igual a 0.1
        if (direccion.magnitude >= 0.1f){
            // Calcula el ángulo a rotar basado en la dirección de la cámara
            float anguloARotar = camara.eulerAngles.y;
            float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloARotar, ref velocidadRotacionSuave, rotacionSuave);
            transform.rotation = Quaternion.Euler(0f, angulo, 0f);

            // Calcula la dirección de movimiento hacia adelante basado en el ángulo de rotación
            Vector3 direccionDelMovimiento = Quaternion.Euler(0f, anguloARotar, 0f) * Vector3.forward;
            controlador.Move(direccionDelMovimiento.normalized * velocidadDeMovimiento * Time.deltaTime);
        }

        // Aplica la gravedad
        velocidad.y += gravedad * Time.deltaTime;
        controlador.Move(velocidad * Time.deltaTime);

        // Actualiza la animación
        animator.SetFloat(variableMovimiento, Mathf.Abs(vertical));
    }


    public void PausarMovimiento()
    {
        velocidadDeMovimiento = 0.0f;
    }

    // Método para reanudar el movimiento del personaje
    public void ReanudarMovimiento()
    {
        velocidadDeMovimiento = velocidadOriginal;
    }
    
}