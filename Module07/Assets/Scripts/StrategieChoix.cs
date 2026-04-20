using UnityEngine;

public abstract class StrategieChoix 
{
    public abstract int ChoisirRessource(Ressource[] ressources, int nbRessourcesDisponibles, Villageois villageois);    
}


