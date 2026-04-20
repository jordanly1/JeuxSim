using UnityEngine;

public class StrategieChoixEquilibre : StrategieChoix
{
    public override int ChoisirRessource(Ressource[] ressources, int nbRessourcesDisponibles, Villageois villageois)
    {
        int indexEquilibre = 0;
        float scorePrecedent = 0;

        for (int i = 0; i < nbRessourcesDisponibles; i++)
        {
            float distance = Vector3.Distance(villageois.transform.position, ressources[i].transform.position);
            //ressource.valeur / distance(joueur, ressource)²
            float score = ressources[i].Valeur / (distance * distance);

            if (score > scorePrecedent)
            {
                scorePrecedent = score;
                indexEquilibre = i;
            }
        }
        return indexEquilibre;
    }
}
