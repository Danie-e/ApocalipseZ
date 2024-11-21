using UnityEngine;

public class GeradorDeZumbis : MonoBehaviour
{
    [SerializeField] private GameObject Zumbi;
    [SerializeField] private float tempoGerarZumbi;
    private float contadorTempo = 0;
    void Start()
    {

    }

    void Update()
    {
        contadorTempo += Time.deltaTime;

        if (contadorTempo >= tempoGerarZumbi)
        {
            Instantiate(Zumbi, transform.position, transform.rotation);
            contadorTempo--;
        }
    }
}
