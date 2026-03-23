using UnityEngine;
using UnityEngine.AI;

public class Patrouille : MonoBehaviour
{
    [SerializeField]
    private Transform[] pointsPatrouille;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private int pointMaintenant;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        while (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            AllerProchainPoint();
        }

        if (navMeshAgent.velocity.magnitude > 0.1f)
            animator.SetBool("isWalking", true);
        else
            animator.SetBool("isWalking", false);
    }

    void AllerProchainPoint()
    {
        pointMaintenant = Random.Range(0, pointsPatrouille.Length);
        navMeshAgent.SetDestination(pointsPatrouille[pointMaintenant].position);
        
    }
}
