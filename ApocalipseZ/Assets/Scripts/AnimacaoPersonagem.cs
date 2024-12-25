using UnityEngine;

public class AnimacaoPersonagem : MonoBehaviour
{
    private Animator meuAnimator;

    private void Awake()
    {
        meuAnimator = GetComponent<Animator>();
    }

    public void Atacar(bool atacando)
    {
        meuAnimator.SetBool("Atacando", atacando);
    }

    public void Movimentar(float valorMovimento)
    {
        meuAnimator.SetFloat("Movendo", valorMovimento);
    }
}
