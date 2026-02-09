using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class userMouvement : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject ground;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {

            var vitesse = 5f;
            float step = vitesse * Time.deltaTime;
            var position = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == ground)
                {
                    var direction = new Vector3(hit.point.x - player.transform.position.x, player.transform.position.y, hit.point.z - player.transform.position.z);

                    StartCoroutine(movePlayer(direction));
                }

            }

        }

    }

    IEnumerator movePlayer(Vector3 direction)
    {
        float speed = 5f;    

        while(player.transform.position == direction)
        {
            player.transform.position += direction * speed * Time.deltaTime;
            direction -= player.transform.position;

        }
        
        





        yield return null;
    }
}
