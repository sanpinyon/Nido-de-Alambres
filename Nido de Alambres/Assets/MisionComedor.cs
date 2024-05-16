using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisionesComedor : MonoBehaviour
{
    public Image Mision1;
    public Image Mision2;
    public Image Mision3;
    public Image Mision4;

    private DialogueController dialogueController;

    void Start()
    {
        Mision1.enabled = true;
        Mision2.enabled = false;
        Mision3.enabled = false;
        Mision4.enabled = false;

    }

    void Update()
    {

    }

    public void MostrarMision2()
    {
        Mision1.enabled = false;
        Mision2.enabled = true;

    }

    public void MostrarMision3()
    {
        Mision2.enabled = false;
        Mision3.enabled = true;
    }

    public void MostrarMision4()
    {
        Mision3.enabled = false;
        Mision4.enabled = true;
    }
}
