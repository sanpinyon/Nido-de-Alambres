using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisionesController : MonoBehaviour
{
    public Image Mision1;
    public Image Mision2;

    private DialogueController dialogueController;

    void Start()
    {
        Mision1.enabled = false;
        Mision2.enabled = false;
    }

    void Update()
    {
        MostrarMision1();
    }

    void MostrarMision1()
    {
        if(dialogueController != null && dialogueController.Index >= dialogueController.Sentences.Length)
        {
            Mision1.enabled = true;
        }
    }

    void MostrarMision2()
    {
        Mision1.enabled = false;
        Mision2.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MostrarMision2();
        }
    }
}


