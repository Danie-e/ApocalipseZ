using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    [SerializeField] private GameObject jogador;
    [SerializeField] public float velocidade = 5;

    private void FixedUpdate()
    {

        float distancia = Vector3.Distance(transform.position, jogador.transform.position);

        if (distancia > 2)
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();

            Vector3 direcao = jogador.transform.position - transform.position;
            rigidbody.MovePosition(rigidbody.position + direcao.normalized * velocidade * Time.deltaTime);

            Quaternion novaRotacao = Quaternion.LookRotation(direcao);

            rigidbody.MoveRotation(novaRotacao);
        }
    }
}
