using UnityEngine;

public class Exercice2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool grandir = true;
    [SerializeField]float vitesseTransformation = 100.01f;
    void Start()
    {
        
        transform.localScale = new Vector3(3,3,3);
        Debug.Log("Magnitude" +  transform.localScale.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        
        
            if (grandir) {

                transform.localScale += new Vector3(vitesseTransformation, vitesseTransformation , vitesseTransformation) * Time.deltaTime;
                
                if (transform.localScale.magnitude >= 100)
                {
                   grandir = false;
                }
            }
            else{

                 transform.localScale -= new Vector3(vitesseTransformation, vitesseTransformation, vitesseTransformation) * Time.deltaTime;
            if (transform.localScale.magnitude <= 20)
                {
                    grandir = true;
                }
            }

          Debug.Log("Magnitude" + transform.localScale.magnitude);


    }
}
