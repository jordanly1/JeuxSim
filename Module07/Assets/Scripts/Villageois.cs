using TMPro;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Villageois : MonoBehaviour
{
    private int or;
    private int plantes;
    private int roches;
    private int numeroRessourceChoisie = -1;
    private NavMeshAgent _navMeshAgent;

    public StrategieChoix strategieChoix;

    [SerializeField] private TMP_Text texteOr;
    [SerializeField] private TMP_Text textePlantes;
    [SerializeField] private TMP_Text texteRoches;
    [SerializeField] private float speed = 1;

    private void Start()
    {
        
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = speed;
    }

    private void Update()
    {
        if (numeroRessourceChoisie == -1)
        {
            AllerVersNouvelleRessource();
        }
        else if (numeroRessourceChoisie != -1 && Vector3.Distance(_navMeshAgent.destination, transform.position) < 1.4f)
        {
            var objet = GameManager.Instance.Ressources[numeroRessourceChoisie];

            var ressource = objet.GetComponent<Ressource>();
            if (ressource.Type == TypeRessource.Or)
                or++;
            else if (ressource.Type == TypeRessource.Plante)
                plantes++;
            else if (ressource.Type == TypeRessource.Roche)
                roches++;

            MiseAJourTextes();
            
            GameManager.Instance.DetruireRessource(numeroRessourceChoisie);
            
            AllerVersNouvelleRessource();
        }
    }

    private void MiseAJourTextes()
    {
        texteOr.text = "Or: " + or;
        textePlantes.text = "Plantes: " + plantes;
        texteRoches.text = "Roches: " + roches;
    }

    private void AllerVersNouvelleRessource()
    {
        // Choix au hasard
        int nbRessourcesDisponibles = GameManager.Instance.NbRessourcesDisponibles;

        if (nbRessourcesDisponibles == 0)
        {
            numeroRessourceChoisie = -1;
        }
        else
        {
            numeroRessourceChoisie = strategieChoix.ChoisirRessource(GameManager.Instance.Ressources, GameManager.Instance.NbRessourcesDisponibles, this);

            var objet = GameManager.Instance.Ressources[numeroRessourceChoisie];

            _navMeshAgent.destination = objet.transform.position;
        }
    }


}