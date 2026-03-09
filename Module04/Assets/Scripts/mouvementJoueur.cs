using UnityEngine;
using UnityEngine.InputSystem;

public class mouvementJoueur : MonoBehaviour
{
    private InputAction move;
    private InputAction jump;
    private CharacterController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        jump = InputSystem.actions.FindAction("Jump");
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        var mouvement = move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(mouvement.x, 0, mouvement.y);
        direction = transform.TransformDirection(direction);
        float magnitudeVitesse = 5f;
        Vector3 vitesse = magnitudeVitesse * direction;
        controller.Move(vitesse * Time.deltaTime);

    }
}
