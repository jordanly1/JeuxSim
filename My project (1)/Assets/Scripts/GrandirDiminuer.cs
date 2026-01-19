using UnityEngine;

public class GrandirDiminuer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localScale = new Vector3(3,3,3);
        Debug.Log("Magnitude" +  transform.localScale.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        
        var vitesse = new Vector3(0.01f, 0.01f, 0.01f);
        while(true)
        {
            if (transform.localScale.magnitude <= 8)
            {
                transform.localScale += vitesse * Time.deltaTime;
            }
            else if (transform.localScale.magnitude >= 2)
            {
                transform.localScale -= vitesse * Time.deltaTime;
            }

        }
        

    }
}
