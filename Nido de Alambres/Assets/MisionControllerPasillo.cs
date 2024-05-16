using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisionControllerPasillo : MonoBehaviour
{
    public Image mision;
    private bool estaColisionando = false;
    void Start()
    {
        mision.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (estaColisionando)
        {
            mision.enabled = true;
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
