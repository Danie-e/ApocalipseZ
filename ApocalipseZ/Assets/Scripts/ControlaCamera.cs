using UnityEngine;

public class ControlaCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 distancia;

    void Start()
    {
        distancia = transform.position - player.transform.position;
    }

    void Update()
    {
        transform.position = player.transform.position + distancia;
    }
}
