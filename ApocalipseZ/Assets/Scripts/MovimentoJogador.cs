using UnityEngine;

public class MovimentoJogador : MovimentoPersonagem
{
    [SerializeField] private LayerMask mascaraChao;

    public void RotacionarJogador()
    {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100, mascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            posicaoMiraJogador.y = transform.position.y;

            Rotacionar(posicaoMiraJogador);
        }
    }
}
