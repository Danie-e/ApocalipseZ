using UnityEngine;

public class Bala : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] private float Velocidade = 20;

    private void Awake()
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
            Destroy(other.gameObject);
    }
}
