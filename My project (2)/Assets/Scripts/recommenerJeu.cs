using UnityEngine;

public class recommenerJeu : MonoBehaviour
{
    private Rigidbody sphereRigidBody;
    private Vector3 initialPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = transform.position;
        sphereRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10f)
        {
            Recommencer();
        }
    }

    void Recommencer()
    {
        transform.position = initialPosition;
        sphereRigidBody.linearVelocity = Vector3.zero;
        sphereRigidBody.angularVelocity = Vector3.zero;
    }
}
