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
    private int points = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AugmenterPoints();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AugmenterPoints()
    {
        points++;
        champPoints.text = "Points: " + points.ToString();
    }
}

