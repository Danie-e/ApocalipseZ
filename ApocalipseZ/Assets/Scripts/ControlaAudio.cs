using UnityEngine;

public class ControlaAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public static AudioSource Instance;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Instance = audioSource;
    }
}
