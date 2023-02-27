using UnityEngine;

public class Bomb : MonoBehaviour
{
    public bool canMove;
    public float speed = 10f;
    [SerializeField] private GameObject explosionFX;

    private void Update()
    {
        if (!canMove)
        {

        }
        if (canMove)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
