using UnityEngine;

public class Exercice2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool grandir = true;
    void Start()
    {
        
        transform.localScale = new Vector3(3,3,3);
        Debug.Log("Magnitude" +  transform.localScale.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        
        var vitesseTransformation = new Vector3(100.01f, 100.01f, 100.01f);
        
            if (grandir) {
                transform.localScale += vitesseTransformation * Time.deltaTime;

                if (transform.localScale.magnitude >= 100)
                {
                   grandir = false;
                }
            }
            else{

                transform.localScale -= vitesseTransformation * Time.deltaTime;
                if (transform.localScale.magnitude <= 20)
                {
                    grandir = true;
                }
            }

    

    }
}
