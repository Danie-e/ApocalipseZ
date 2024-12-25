using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{
    [SerializeField] private float velocidade = 1;
    [SerializeField] public int Vida = 10;

    [SerializeField] public GameObject TextoGameOver;
    [SerializeField] private ControlaInterface controlaInterface;
    [SerializeField] private AudioClip somDeDano;

    private MovimentoJogador meuMovimento;
    private AnimacaoPersonagem minhaAnimacao;

    private float eixoX;
    private float eixoZ;


    private void Start()
    {
        Time.timeScale = 1;
        meuMovimento = GetComponent<MovimentoJogador>();
        minhaAnimacao = GetComponent<AnimacaoPersonagem>();
    }

    private void Update()
    {
        if (Vida <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
                SceneManager.LoadScene("Game");
        }
    }

    private void FixedUpdate()
    {
        eixoX = Input.GetAxis("Horizontal");
        eixoZ = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(eixoX, 0, eixoZ);

        meuMovimento.Movimentar(direcao, velocidade);
        meuMovimento.RotacionarJogador();

        minhaAnimacao.Movimentar(direcao.magnitude);
    }

    public void ReceberDano()
    {
        Vida--;
        controlaInterface.AtualizarSliderVidaJogador();
        ControlaAudio.Instance.PlayOneShot(somDeDano);
        if (Vida <= 0)
        {
            Time.timeScale = 0;
            TextoGameOver.SetActive(true);
        }
    }

}
