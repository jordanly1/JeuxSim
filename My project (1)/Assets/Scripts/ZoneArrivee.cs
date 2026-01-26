using UnityEngine;

public class ZoneArrivee : MonoBehaviour
{

    [SerializeField]
    private GameObject ball;
    private float tempsAttente = 0;
    private bool reussi = false;

    private MouvementJoueurEx2 scriptDeplacement;
    private SystemPoints systemPoints = new SystemPoints();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (reussi)
        {
            GameObject.Instantiate(ball);
            reussi = false;


            if (scriptDeplacement == null)
            {
                scriptDeplacement = ball.GetComponent<MouvementJoueurEx2>();
            }

            scriptDeplacement.ReplacerJoueur();

            systemPoints.AugmenterPoints();
        }


    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == ball)
        {
            reussi = true;
        }
    }


}
