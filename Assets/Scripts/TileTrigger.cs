using UnityEngine;

public class TileTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(true);
        }
    }
}
