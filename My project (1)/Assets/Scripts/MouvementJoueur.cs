using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementJoueur : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private InputAction _move;
    private Rigidbody sphereRigidBody;
    [SerializeField]
    private float niveauForce;

    void Start()
    {

        _move = InputSystem.actions.FindAction("Move");
        sphereRigidBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 mouvement = _move.ReadValue<Vector2>();
        Vector3 force = new Vector3(mouvement.x, 0, mouvement.y);
        force *= niveauForce;
        sphereRigidBody.AddForce(force);
    }

   


}
