using UnityEngine;

public class MenuControlleur : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject villageois;
    private Villageois _villageoisScript;

    void Start()
    {
        _villageoisScript = villageois.GetComponent<Villageois>();
    }
    public void choisirHasard()
    {
        _villageoisScript.strategieChoix = new StrategieChoixAuHasard();
    }

    public void choisirPlusProche()
    {
        _villageoisScript.strategieChoix = new StrategieChoixPlusProche();
    }

    public void choisirPlusRiche()
    {
        _villageoisScript.strategieChoix = new StrategieChoixEquilibre();
    }
}
