using UnityEngine;

public class VehicalHitBox : MonoBehaviour
{
    [SerializeField] private MoveForward moveForward;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            moveForward.speed = 0;
        }
    }
}
