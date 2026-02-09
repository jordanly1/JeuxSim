using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class bougerBras : MonoBehaviour
{
    float vitesseDeplacement = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate();

        if (transform.localPosition.x < -0.2f)
        {
            directionDeplacement = new Vector3(1f, 0f, 0f);

        }
        else if (transform.localPosition.x > 0.2f)
        {
            directionDeplacement = new Vector3(-1f, 0f, 0f);
        }

    }
}
