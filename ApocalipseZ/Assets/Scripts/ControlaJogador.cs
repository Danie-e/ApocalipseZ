using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{
    [SerializeField] private float velocidade = 1;
    [SerializeField] private LayerMask mascaraChao;
    [SerializeField] public GameObject TextoGameOver;
    [SerializeField] private ControlaInterface controlaInterface;

    private Animator anim;
    private Rigidbody rigidbody;

    private float eixoX;
    private float eixoZ;
    [SerializeField] public int Vida = 10;

    private void Start()
    {
        Time.timeScale = 1;
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
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

    public void ReceberDano()
    {
        Vida--;
        controlaInterface.AtualizarSliderVidaJogador();
        if (Vida <= 0)
        {
            Time.timeScale = 0;
            TextoGameOver.SetActive(true);
        }
    }
}
