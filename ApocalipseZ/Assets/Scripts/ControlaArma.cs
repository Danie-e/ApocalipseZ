using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    [SerializeField] private GameObject bala;
    [SerializeField] private GameObject canoArma;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bala, canoArma.transform.position, canoArma.transform.rotation);
        }
    }
}
