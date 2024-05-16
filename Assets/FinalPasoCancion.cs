using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class FinalPasoCancion : MonoBehaviour
{
    public static FinalPasoCancion instance;
 
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
