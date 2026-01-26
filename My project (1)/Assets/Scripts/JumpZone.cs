using UnityEngine;

public class JumpZone : MonoBehaviour
{

    [SerializeField]
    private GameObject ball;

    private MouvementJoueurEx2 scriptJump;
    [SerializeField]
    private float jumpForce = 10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ball)
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }



}
