using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class triggerBurla : MonoBehaviour
{
    public AudioSource SonidoBurla;

    void OnTriggerEnter (Collider other)
    {
        SonidoBurla.Play();
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}