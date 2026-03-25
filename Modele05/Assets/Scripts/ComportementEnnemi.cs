using UnityEngine;
using UnityEngine.AI;

public class ComportementEnnemi : MonoBehaviour
{
    [SerializeField]
    public Transform[] pointsPatrouille;
    [SerializeField]
    public GameObject joueur;


    [HideInInspector]public NavMeshAgent navMeshAgent;
    [HideInInspector]public Animator animator;



    public Patrouille etatPatrouille;
    public EtatPoursuite etatPoursuite;
    public EtatAttente etatAttente;
    public EtatAttaque etatAttaque;

    private EtatEnnemi etatCourant;
    public int pointMaintenant;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        etatPatrouille = new Patrouille(this);
        etatPoursuite = new EtatPoursuite(this);
        etatAttente = new EtatAttente(this);
        etatPatrouille = new Patrouille(this);


        etatCourant = etatPatrouille;
        etatCourant.Entrer();

    }

    // Update is called once per frame
    void Update()
    {
        etatCourant.Executer(Time.deltaTime);
    }


    public void ChangerEtat(EtatEnnemi nouvelEtat)
    {
        etatCourant.Sortir();
        etatCourant = nouvelEtat;
        etatCourant.Entrer();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == joueur)
        {
            Debug.Log("Le joueur a été touché !");
             ChangerEtat(etatPatrouille);
        }
    }
}


