using UnityEngine;
using UnityEngine.UI;

public class ControlaInterface : MonoBehaviour
{
    private ControlaJogador scriptControlaJogador;
    [SerializeField] public Slider SliderVidaJogador;

    void Start()
    {
        scriptControlaJogador = GameObject.FindWithTag("Player").GetComponent<ControlaJogador>();
        SliderVidaJogador.maxValue = scriptControlaJogador.Vida;
    }

    void Update()
    {
    }

    public void AtualizarSliderVidaJogador()
    {
        SliderVidaJogador.value = scriptControlaJogador.Vida;
    }
}
