using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonesFuncionamiento : MonoBehaviour
{
    public Button BotonJugar;
    public Button BotonConfiguracion;
    public Button BotonSalir;
    // Start is called before the first frame update
    void Start()
    {
        BotonJugar.onClick.AddListener(Jugar);
        BotonSalir.onClick.AddListener(Salir);
        BotonConfiguracion.onClick.AddListener(Configuracion);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Jugar()
    {
        SceneManager.LoadScene("Calle");
        Time.timeScale = 1f;
    }

    void Salir()
    {
        Application.Quit();
    }

    void Configuracion()
    {
        SceneManager.LoadScene("Configuracion");
    }
}
