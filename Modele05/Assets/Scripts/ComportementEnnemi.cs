using UnityEngine;
using UnityEngine.AI;

public class ComportementEnnemi : MonoBehaviour
{
    [SerializeField]
    private Transform[] pointsPatrouille;
    [SerializeField]
    public GameObject joueur;


    public NavMeshAgent navMeshAgent;
    public Animator animator;



    public Patrouille etatPatrouille;
    public EtatPoursuite etatPoursuite;
    public EtatAttente etatAttente;
    public EtatAttaque etatAttaque;

    private EtatEnnemi etatCourant;

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

    }

    public void AllerProchainPoint()
    {
        pointMaintenant = Random.Range(0, pointsPatrouille.Length);
        navMeshAgent.SetDestination(pointsPatrouille[pointMaintenant].position);

    }

    public void ChangerEtat(EtatEnnemi nouvelEtat)
    {
        etatCourant.Sortir();
        etatCourant = nouvelEtat;
    }

    public bool joueurVisible()
    {

       Vector3 directionJoueur = (joueur.transform.position - transform.position).normalized;
       float angle = Vector3.Angle(transform.forward, directionJoueur);
       if (angle < 60)
       {
         navMeshAgent.SetDestination(joueur.transform.position);
         ChangerEtat(etatPoursuite);

            return true;
       }
        return false;
    }
}


