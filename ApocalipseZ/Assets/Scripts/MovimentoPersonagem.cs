using UnityEngine;

public class MovimentoPersonagem : MonoBehaviour
{
    private Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public void Movimentar(Vector3 direcao, float velocidade)
    {
        rigidbody.MovePosition(GetComponent<Rigidbody>().position + direcao.normalized * velocidade * Time.deltaTime);

    }
    public void Rotacionar(Vector3 direcao)
    {
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        rigidbody.MoveRotation(novaRotacao);
    }
}
