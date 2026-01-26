using TMPro;
using UnityEngine;

public class SystemPoints : MonoBehaviour
{

    [SerializeField]
    private TMP_Text champPoints;
    [SerializeField]
    private GameObject balle;
    [SerializeField]
    private ZoneArrivee zone;


    private int points;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points  = 0;
        champPoints.text = points.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AugmenterPoints()
    {
        points++;
        champPoints.text = points.ToString();
    }
}

