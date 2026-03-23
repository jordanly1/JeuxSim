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
        sujet.AllerProchainPoint();

    }
    public  override void Sortir() { 

       sujet.animator.SetBool("Walk", false);


    }
    public override void Executer(float deltaTime)
    {
        if(sujet.navMeshAgent.remainingDistance < 0.5f)
        {
            sujet.AllerProchainPoint();
        }
    }

}
