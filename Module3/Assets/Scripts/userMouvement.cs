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
            movePlayer();
        }
        
    }

    IEnumerator movePlayer()
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
                player.transform.position = Vector3.MoveTowards(player.transform.position, hit.point, 0.005f);
            }
                
        }





        yield return null;
    }
}
