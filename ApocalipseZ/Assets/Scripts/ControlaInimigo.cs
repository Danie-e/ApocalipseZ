using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    [SerializeField] private GameObject jogador;
    [SerializeField] public float velocidade = 5;

    private void Start()
    {
        jogador = GameObject.FindWithTag("Player");

        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        float distancia = Vector3.Distance(transform.position, jogador.transform.position);
        Vector3 direcao = jogador.transform.position - transform.position;

        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        rigidbody.MoveRotation(novaRotacao);

        if (distancia > 2.5)
        {
            rigidbody.MovePosition(rigidbody.position + direcao.normalized * velocidade * Time.deltaTime);
            GetComponent<Animator>().SetBool("Atacando", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Atacando", true);
        }
    }
    public void AtacaJogador()
    {
        Time.timeScale = 0;
        jogador.GetComponent<ControlaJogador>().textoGameOver.SetActive(true);
        jogador.GetComponent<ControlaJogador>().Vivo = false;
    }
}
