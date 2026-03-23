using UnityEngine;

public class EtatAttaque : EtatEnnemi
{
    public EtatAttaque(ComportementEnnemi comportement) : base(comportement)
    {
    }

    public override void Entrer()
    {
        sujet.animator.SetBool("Walk", false);
        sujet.transform.LookAt(sujet.joueur.transform);
        sujet.animator.SetTrigger("Attack");

    }
    public override void Sortir()
    {

    }
    public override void Executer(float deltaTime)
    {
        sujet.ChangerEtat(sujet.etatPoursuite);
    }

}
