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
    private GameObject ground;
    [SerializeField]
    private float rotationSpeed = 80f;
    [SerializeField]
    private float speed = 5f;
    private Rigidbody _playerRigidBody;
    private Vector3 objectif;
    private Coroutine coroutine;
    private Coroutine headCoroutine;
    private Vector3 placeDepart;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {

            var position = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(position);
            RaycastHit hit;



            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == ground)
                {
                    if (coroutine != null) StopCoroutine(coroutine);
                    if(headCoroutine != null) StopCoroutine(headCoroutine);


                    objectif = hit.point;
                    objectif.y = _playerRigidBody.position.y;   

                    Vector3 direction = (objectif - _playerRigidBody.position).normalized;

                    headCoroutine = StartCoroutine(rotateHead(direction));
                    coroutine = StartCoroutine(movePlayer(direction));
                }

            }

        }
    }

    IEnumerator movePlayer(Vector3 direction)
    {

        while (Vector3.Distance(_playerRigidBody.position, objectif) > 1f)
        {
            _playerRigidBody.position += speed * direction * Time.deltaTime; 
            yield return null;

        }
    }

    IEnumerator rotateHead(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        while (Quaternion.Angle(_playerRigidBody.rotation, targetRotation) > 0.1f)
        {
            _playerRigidBody.rotation =
        Quaternion.RotateTowards(_playerRigidBody.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            yield return null;
        }

    }
}
