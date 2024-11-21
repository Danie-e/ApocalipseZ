using UnityEngine;

public class GeradorDeZumbis : MonoBehaviour
{
    [SerializeField] private GameObject zumbi;
    [SerializeField] private float tempoGerarZumbi;
    private float contadorTempo = 0;

    void Update()
    {
        contadorTempo += Time.deltaTime;

        if (contadorTempo >= tempoGerarZumbi)
        {
            Instantiate(zumbi, transform.position, transform.rotation);
            contadorTempo -= tempoGerarZumbi;
        }
    }
}
