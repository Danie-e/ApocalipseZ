using UnityEngine;

public class ControlaCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 distancia;

    void Start()
    {
        distancia = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + distancia;
    }
}
