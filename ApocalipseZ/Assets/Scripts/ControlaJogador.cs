using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(eixoX,0, eixoZ);

        transform.Translate(direcao);
    }
}
