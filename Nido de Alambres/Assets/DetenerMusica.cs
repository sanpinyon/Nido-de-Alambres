using UnityEngine;

public class DetenerMusica : MonoBehaviour
{
    void Start()
    {
        AudioSource audioSource = FindObjectOfType<AudioSource>();
        
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}
