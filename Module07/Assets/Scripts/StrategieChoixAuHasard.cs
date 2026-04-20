using UnityEngine;

public class StrategieChoixAuHasard : StrategieChoix
{
    public override int ChoisirRessource(Ressource[] ressources, int nbRessourcesDisponibles, Villageois villageois)
    {
        return Random.Range(0, nbRessourcesDisponibles);
    }
}
