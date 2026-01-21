using UnityEngine;

public class CameraTopDown : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float hauteur;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlacerCamera();
    }
    private void LateUpdate()
    {
        PlacerCamera();
    }
    private void PlacerCamera()
    {
        float positionX = player.transform.position.x;
        float positionZ = player.transform.position.z;

        transform.localPosition = new Vector3(positionX, hauteur, positionZ);
    }
}
