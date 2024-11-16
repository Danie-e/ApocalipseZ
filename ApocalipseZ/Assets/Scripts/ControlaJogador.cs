using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    [SerializeField] private float velocidade = 1;

    private void FixedUpdate()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(eixoX, 0, eixoZ);

        transform.Translate(direcao * velocidade);
    }
}
