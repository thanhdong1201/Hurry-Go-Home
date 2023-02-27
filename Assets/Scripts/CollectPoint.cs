using UnityEngine;

public class CollectPoint : MonoBehaviour
{
    [SerializeField] private ScoreSO scoreSO;
    [SerializeField] private int scoreCanGet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreSO.AddScore(scoreCanGet);
            Destroy(gameObject);
        }
        
    }
}
