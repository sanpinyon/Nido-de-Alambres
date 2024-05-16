using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class triggerSusurro : MonoBehaviour
{
    public AudioSource SonidoSusurro;

    void OnTriggerEnter (Collider other)
    {
        SonidoSusurro.Play();
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
