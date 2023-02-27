using UnityEngine.AI;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    private Animator anim;
    bool catchPlayer;

    private void Awake()
    {
        GameObject g = GameObject.FindWithTag("Player");
        player = g.GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        agent.SetDestination(player.position);
    }
    private void Update()
    {
        bool alreadyCatch = false;
        float distance = Vector3.Distance(player.position, transform.position);

        if (!alreadyCatch)
        {
            if (distance > agent.stoppingDistance)
            {
                anim.SetBool("isChasing", true);
                agent.SetDestination(player.position);
            }
            if (distance <= agent.stoppingDistance)
            {
                agent.SetDestination(transform.position);
                catchPlayer = true;
            }
        }
        if (catchPlayer)
        {
            
            alreadyCatch = true;
            anim.SetBool("isAttacking", true);
            transform.LookAt(player);
        }
    }
}
