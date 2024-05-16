using UnityEngine;

public class OcultarRaton : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    public void MostrarRaton()
    {
        Cursor.visible = true;
    }

    public void EsconderRaton()
    {
        Cursor.visible = false;
    }
}
