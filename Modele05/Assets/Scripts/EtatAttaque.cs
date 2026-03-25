using UnityEngine;

public class EtatAttaque : EtatEnnemi
{
    public EtatAttaque(ComportementEnnemi comportement) : base(comportement)
    {
    }

    public override void Entrer()
    {
        sujet.animator.SetBool("Walk", false);
        sujet.navMeshAgent.isStopped = true;
        sujet.transform.LookAt(sujet.joueur.transform);
        sujet.animator.SetTrigger("Attack");

    }
    public override void Sortir()
    {

    }
    public override void Executer(float deltaTime)
    {
        Vector3 positionJoueur = sujet.joueur.transform.position;
        Vector3 positionEnnemi = sujet.transform.position;
        float distanceJoueur = (positionJoueur - positionEnnemi).magnitude;

        if (distanceJoueur > 2.5f)
        {
            sujet.ChangerEtat(sujet.etatPatrouille);
        }
    }

}
