using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonAtras : MonoBehaviour
{
    public Button Botonatras;
    void Start()
    {
        Botonatras.onClick.AddListener(Atras);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Atras()
    {
        SceneManager.LoadScene("MenuInicio");
    }
}