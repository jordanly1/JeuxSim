using UnityEngine;

public class ButFinal : MonoBehaviour
{
    [SerializeField]
    private GameObject joueur;
    private float tempsAttente = 0;
    private bool attenteDemarrer = false;

    //Sert a remettre le joueur au debut quand il a fini le jeu pour le recommmencer
    private MouvementJoueur scriptMouvement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (attenteDemarrer)
        {
            tempsAttente += Time.deltaTime;
        }

        if(tempsAttente > 2)
        {
            tempsAttente = 0;
            attenteDemarrer = false;

            if(scriptMouvement == null)
            {
                scriptMouvement = joueur.GetComponent<MouvementJoueur>();
            }

            scriptMouvement.ReplacerJoueur();
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == joueur)
        {
            attenteDemarrer = true;
        }
    }
}
