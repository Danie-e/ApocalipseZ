using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    [SerializeField] private GameObject bala;
    [SerializeField] private GameObject canoArma;
    [SerializeField] private AudioClip somDeTiro;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bala, canoArma.transform.position, canoArma.transform.rotation);
            ControlaAudio.Instance.PlayOneShot(somDeTiro);
        }
    }
}
