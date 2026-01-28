using UnityEngine;

public class GestionJeu : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;
    private MouvementJoueurEx2 joueur;

    [SerializeField]
    private GameObject texte;
    private SystemPoints systemPoints;

    [SerializeField]
    private ZoneArrivee zone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zone.ZoneAtteinteHandler += replacerJoueur;
        zone.ZoneAtteinteHandler += augmenterPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void replacerJoueur()
    {

        GameObject cloneBall = GameObject.Instantiate(ball);
        cloneBall.GetComponent<MouvementJoueurEx2>().enabled = false;

        if (joueur == null) joueur = ball.GetComponent<MouvementJoueurEx2>();

        joueur.ReplacerJoueur();

    }

    void augmenterPoints()
    {
        if (systemPoints == null) systemPoints = texte.GetComponent<SystemPoints>();

        systemPoints.AugmenterPoints();
    }
}
