using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    [SerializeField] private GameObject jogador;
    [SerializeField] private float velocidade = 5;
    private Rigidbody rigidbody;
    private Animator animator;

    private void Start()
    {
        jogador = GameObject.FindWithTag("Player");

        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, jogador.transform.position);
        Vector3 direcao = jogador.transform.position - transform.position;

        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        rigidbody.MoveRotation(novaRotacao);

        if (distancia > 2.5)
        {
            rigidbody.MovePosition(rigidbody.position + direcao.normalized * velocidade * Time.deltaTime);
            animator.SetBool("Atacando", false);
        }
        else
            animator.SetBool("Atacando", true);
    }
    public void AtacaJogador()
    {
        Time.timeScale = 0;
        jogador.GetComponent<ControlaJogador>().TextoGameOver.SetActive(true);
        jogador.GetComponent<ControlaJogador>().Vivo = false;
    }
}
