using UnityEngine;
using UnityEngine.AI;

public class Patrouille : MonoBehaviour
{
    [SerializeField]
    private Transform[] pointsPatrouille;
    private NavMeshAgent navMeshAgent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        var destionation = pointsPatrouille[Random.Range(0, pointsPatrouille.Length - 1)];

        navMeshAgent.SetDestination(destionation.position);
    }
}
