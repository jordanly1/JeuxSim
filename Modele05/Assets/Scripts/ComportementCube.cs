using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ComportementCube : MonoBehaviour
{
    [SerializeField]
    private GameObject terrain;
    private InputAction _espace;
    private NavMeshAgent navMeshAgent;
    private Vector3 objectif;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        navMeshAgent = GetComponent<NavMeshAgent>();
        _espace =  InputSystem.actions.FindAction("Jump");
        navMeshAgent.destination = new Vector3(2,0,-16);
    }

    // Update is called once per frame
    void Update()
    {

        //if (_espace.WasPressedThisFrame())
        //{
        //    var randomX = Random.Range(0, 2) == 0 ? -1 : 1;
        //    var randomZ = Random.Range(0, 2) == 0 ? -1 : 1;

        //    navMeshAgent.destination = new Vector3(randomX, 0, randomZ);

        //}



        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 positionSouris = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(positionSouris);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == terrain)
                {

                    objectif = hit.point;

                    navMeshAgent.SetDestination(objectif);

                }
            }
        }
    }
}
