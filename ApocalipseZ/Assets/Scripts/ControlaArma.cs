using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    [SerializeField] private GameObject Bala;
    [SerializeField] private GameObject CanoArma;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bala, CanoArma.transform.position, CanoArma.transform.rotation);
        }
    }
}
