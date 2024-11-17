using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    [SerializeField] private float velocidade = 1;
    private Animator anim;
    private Rigidbody rigidbody;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(eixoX, 0, eixoZ);

        rigidbody.MovePosition(rigidbody.position + (direcao * velocidade * Time.deltaTime));

        if (direcao != Vector3.zero)
            anim.SetBool("Correr", true);
        else
            anim.SetBool("Correr", false);
    }
}
