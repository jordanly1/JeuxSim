using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementJoueurEx2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private InputAction _move;
    public Rigidbody sphereRigidBody;

    [SerializeField]
    private GameObject trampoline;

    [SerializeField]
    private float niveauForce;


    private Vector3 positionDepart;

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

    public void ReplacerJoueur()
    {
        transform.position = positionDepart;
        sphereRigidBody.linearVelocity = Vector3.zero;
        sphereRigidBody.angularVelocity = Vector3.zero;
    }





}
