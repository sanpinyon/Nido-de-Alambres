using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EfectosSonido : MonoBehaviour
{
    public AudioSource SonidoSusurro;
    public AudioSource SonidoBurla;
    public GameObject susurro1;
    public GameObject susurro2;
    // public GameObject burla1;
    // public GameObject burla2;
    // public GameObject burlaSusurro3;
    private bool estaColisionando = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (estaColisionando && gameObject.CompareTag("Susurro"))
        {
            SonidoSusurro.Play();
        } 
        if (gameObject == susurro1 || gameObject == susurro2)
        {
            SonidoSusurro.Play();
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
}
