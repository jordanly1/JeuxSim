using UnityEngine;
using UnityEngine.AI;

public class EtatPoursuite : EtatEnnemi
{
    public EtatPoursuite(ComportementEnnemi _sujet) : base(_sujet)
    {
    }
    public override void Entrer()
    {
        sujet.animator.SetBool("Walk", true);

    }
    public override void Sortir()
    {

    }
    public override void Executer(float deltaTime)
    {
        if(sujet.joueurVisible())
        {
            sujet.navMeshAgent.SetDestination(sujet.joueur.transform.position);

            if(sujet.navMeshAgent.remainingDistance < 2.5f)
            {
                sujet.ChangerEtat(sujet.etatAttaque);
            }
        }
        else
        {
            sujet.ChangerEtat(sujet.etatAttente);
        }
    }
}
