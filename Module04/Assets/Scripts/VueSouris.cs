using UnityEngine;
using UnityEngine.InputSystem;

public class VueSouris : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private InputAction mouvementSouris;
    private float vitesseRotation = 5f;
    private Quaternion rotationInitiale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouvementSouris =  InputSystem.actions.FindAction("Look");
        rotationInitiale = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 _mouvement = mouvementSouris.ReadValue<Vector2>();


        player.transform.Rotate(0, _mouvement.x * vitesseRotation * Time.deltaTime, 0);
        transform.Rotate(_mouvement.y * vitesseRotation * Time.deltaTime, 0, 0);

        if (transform.rotation.x > rotationInitiale.x + 30f)
        {
            transform.rotation = Quaternion.Euler(rotationInitiale.x + 30f, transform.rotation.y, transform.rotation.z);
        }
        else if (transform.rotation.x < rotationInitiale.x - 30f)
        {
            transform.rotation = Quaternion.Euler(rotationInitiale.y - 30f, transform.rotation.y, transform.rotation.z);

        }
    }
}
