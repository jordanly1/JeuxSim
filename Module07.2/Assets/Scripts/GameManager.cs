using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabsRessources;
    [SerializeField]
    private int nbRessources;
    [HideInInspector]
    public List<Ressource> ressources;
    public static GameManager Instance;

    void Awake()
    {
        // Valide qu'il y a un seul GameManager
        Debug.Assert(Instance == null);
        Instance = this;
    }

    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("StrategieChoix"));
        ChargerDonnees();
        CreerRessources();

    }

    private void CreerRessources()
    {
        for (int i = 0; i < nbRessources; i++)
        {
            float positionX = Random.Range(-25, 25);
            float positionZ = Random.Range(-25, 25);
            Vector3 position = new Vector3(positionX, 0.5f, positionZ);

            int indexAleatoire = Random.Range(0, prefabsRessources.Count);
            GameObject ressourceAleatoire = Instantiate(prefabsRessources[indexAleatoire], position, Quaternion.identity);
            ressources.Add(ressourceAleatoire.GetComponent<Ressource>());
        }
    }

    void Update()
    {
        if (ressources.Count == 0)
        {
            CreerRessources();
        }
    }

    public void DetruireRessource(int numeroRessourceChoisie)
    {
        Ressource ressource = ressources[numeroRessourceChoisie];
        Destroy(ressource.gameObject);
        ressources.Remove(ressource);
    }

    void OnApplicationQuit()
    {
        Villageois villageois = FindFirstObjectByType<Villageois>();

        PlayerPrefs.SetString("StrategieChoix", villageois.strategieChoix.GetType().Name);
        PlayerPrefs.Save();

        var donnees = new DonneesStrategie();
        donnees.nombreOrRecuperee = villageois.or;
        donnees.nombrePlantesRecuperee = villageois.plantes;
        donnees.nombreRochesRecuperee = villageois.roches;
        donnees.NbRessourcesDisponibles = ressources.Count;

        string json = JsonUtility.ToJson(donnees);
        File.WriteAllText(Application.persistentDataPath + "/donnesRessources.json", json);

    }

    private void ChargerDonnees()
    {
        if (File.Exists(Application.persistentDataPath + "/donnesRessources.json"))
        {
            Debug.Log("Reload successful");
            Villageois villageois = FindFirstObjectByType<Villageois>();

            var texte = File.ReadAllText(Application.persistentDataPath + "/donnesRessources.json");
            var donnees = JsonUtility.FromJson<DonneesStrategie>(texte);

            villageois.or = donnees.nombreOrRecuperee;
            villageois.plantes = donnees.nombrePlantesRecuperee;
            villageois.roches = donnees.nombreRochesRecuperee;

            nbRessources = donnees.NbRessourcesDisponibles;
            villageois.MiseAJourTextes();

            return;
        }

        Debug.Log("Nothing saved");




    }



}
