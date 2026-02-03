using UnityEngine;
using UnityEngine.InputSystem;

public class Balance : MonoBehaviour
{
    private InputAction _move;
    private Rigidbody sphereRigidBody;
    [SerializeField]
    private float niveauForce;



    private Vector3 positionDepart;

    void Start()
    {
        positionDepart = transform.position;
        _move = InputSystem.actions.FindAction("Move");
        sphereRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        Vector2 mouvement = _move.ReadValue<Vector2>();
        Vector3 force = new Vector3(mouvement.x, 0, mouvement.y);
        force *= niveauForce;
        sphereRigidBody.AddTorque(force);
    }

    public void ReplacerJoueur()
    {
        transform.position = positionDepart;
        sphereRigidBody.linearVelocity = Vector3.zero;
        sphereRigidBody.angularVelocity = Vector3.zero;
    }

}
