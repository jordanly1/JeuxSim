using UnityEngine;

public class StrategieChoixPlusProche : StrategieChoix
{
    public override int ChoisirRessource(Ressource[] ressources, int nbRessourcesDisponibles, Villageois villageois)
    {
        int indexPlusProche = 0;
        float distanceMin = float.MaxValue;

        for (int i = 0; i < nbRessourcesDisponibles; i++)
        {
            float distance = Vector3.Distance(villageois.transform.position, ressources[i].transform.position);
            if (distance < distanceMin)
            {
                distanceMin = distance;
                indexPlusProche = i;
            }
        }

        return indexPlusProche;
    }
}
