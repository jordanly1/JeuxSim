using UnityEngine;

public class EtatAttente : EtatEnnemi
{
    float sec;
    public EtatAttente(ComportementEnnemi _sujet) : base(_sujet)
    {
    }


    public override void Entrer()
    {
       sujet.animator.SetBool("Walk", false);
       sujet.navMeshAgent.isStopped = true;
       sec = Random.Range(3, 5);

    }
    public override void Sortir()
    {

    }
    public override void Executer(float deltaTime)
    {
       sec -= Time.deltaTime;

        if(sec < 0)
        {
            sujet.ChangerEtat(sujet.etatPatrouille);
            sujet.navMeshAgent.isStopped = false;
        }


    }

}
