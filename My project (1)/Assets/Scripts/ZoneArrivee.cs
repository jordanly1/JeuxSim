using System;
using UnityEngine;

public class ZoneArrivee : MonoBehaviour
{

    [SerializeField]
    private GameObject ball;

    public event Action ZoneAtteinteHandler;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == ball)
        {
            // Avertir les objets interesses que la zone a ete atteinte
            ZoneAtteinteHandler?.Invoke();
        }
    }


}
