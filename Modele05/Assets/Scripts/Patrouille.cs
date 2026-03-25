using UnityEngine;
using UnityEngine.AI;

public class Patrouille : EtatEnnemi
{

    public Patrouille(ComportementEnnemi _sujet) : base(_sujet)
    {
    }


    public  override void Entrer() {

        sujet.animator.SetBool("Walk", true);
        sujet.navMeshAgent.isStopped = false;
        AllerProchainPoint();

    }
    public  override void Sortir() { 

       sujet.animator.SetBool("Walk", false);


    }
    public override void Executer(float deltaTime)
    {
        if (sujet.joueurVisible()) { 
            sujet.ChangerEtat(sujet.etatPoursuite);
        }
        else if (sujet.navMeshAgent.remainingDistance < 0.5f)
        {
            AllerProchainPoint();

        }
      
    }


    public void AllerProchainPoint()
    {
        sujet.pointMaintenant = Random.Range(0, sujet.pointsPatrouille.Length);
        sujet.navMeshAgent.SetDestination(sujet.pointsPatrouille[sujet.pointMaintenant].position);

    }

}
