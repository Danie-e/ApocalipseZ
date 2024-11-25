using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float Velocidade = 20;
    [SerializeField] private AudioClip somDeMorte;

    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + transform.forward * Velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        if (other.tag.Equals("Inimigo"))
        {
            ControlaAudio.Instance.PlayOneShot(somDeMorte);
            Destroy(other.gameObject);
        }
    }
}
