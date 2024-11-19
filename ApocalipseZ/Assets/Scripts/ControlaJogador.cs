using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    [SerializeField] private float velocidade = 1;
    [SerializeField] private LayerMask mascaraChao;
    private Animator anim;
    private Rigidbody rigidbody;
    float eixoX;
    float eixoZ;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rigidbody = GetComponent<Rigidbody>();

        eixoX = Input.GetAxis("Horizontal");
        eixoZ = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(eixoX, 0, eixoZ);

        rigidbody.MovePosition(rigidbody.position + (direcao * velocidade * Time.deltaTime));

        if (direcao != Vector3.zero)
            anim.SetBool("Correr", true);
        else
            anim.SetBool("Correr", false);

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100, mascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            rigidbody.MoveRotation(novaRotacao);
        }
    }
}
