using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    [SerializeField] private float velocidade = 5;
    private GameObject jogador;
    private MovimentoPersonagem meuMovimento;
    private AnimacaoPersonagem minhaAnimacao;

    private void Start()
    {
        jogador = GameObject.FindWithTag("Player");
        AleatorizarZumbi();
        meuMovimento = GetComponent<MovimentoPersonagem>();
        minhaAnimacao = GetComponent<AnimacaoPersonagem>();
    }

    private void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, jogador.transform.position);
        Vector3 direcao = jogador.transform.position - transform.position;

        meuMovimento.Rotacionar(direcao);

        if (distancia > 2.5)
        {
            meuMovimento.Movimentar(direcao, velocidade);
            minhaAnimacao.Atacar(false);
        }
        else
            minhaAnimacao.Atacar(true);

    }
    public void AtacaJogador()
    {
        jogador.GetComponent<ControlaJogador>().ReceberDano();
    }
    private void AleatorizarZumbi()
    {
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }
}
