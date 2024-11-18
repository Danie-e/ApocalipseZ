using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    [SerializeField] private GameObject jogador;
    [SerializeField] public float velocidade = 5;
    private void FixedUpdate()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        Vector3 direcao = jogador.transform.position - transform.position;
        rigidbody.MovePosition(rigidbody.position + direcao.normalized * velocidade * Time.deltaTime);
    }
}
