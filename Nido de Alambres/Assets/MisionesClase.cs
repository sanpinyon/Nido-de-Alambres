using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MisionesClase : MonoBehaviour
{
    public Image dibujo;
    public Image mision1;
    public Image mision2;
    public Image explicacion;
    public GameObject corcho;
    public GameObject Leo;
    public GameObject dibujo2;
    public AudioSource papel;
    //public AudioSource triste;

    private bool estaColisionando = false;
    private bool dibujoActivado = false;
    private float tiempoTranscurrido = 0f;
    public float tiempoParaDesactivar = 3f;

    void Start()
    {
        dibujo.enabled = false;
        mision1.enabled = false;
        mision2.enabled = false;
        explicacion.enabled = false;
    }

    void Update()
    {
        if (estaColisionando && Input.GetKeyDown(KeyCode.E))
        {
            dibujo.enabled = true;
            dibujoActivado = true;
            mision1.enabled = false;
            explicacion.enabled = true;
        }

        if (dibujoActivado)
        {
            tiempoTranscurrido += Time.deltaTime;

            if (tiempoTranscurrido >= tiempoParaDesactivar)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    dibujo.enabled = false;
                    dibujoActivado = false;
                    explicacion.enabled = false;
                    tiempoTranscurrido = 0f;
                    MostrarMision2();
                    dibujo2.SetActive(false);
                    papel.Play();
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaColisionando = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaColisionando = false;
        }
    }

    public void MostrarMision1()
    {
        mision1.enabled = true;
        mision2.enabled = false;
    }

    public void MostrarMision2()
    {
        mision1.enabled = false;
        mision2.enabled = true;
    }
}


