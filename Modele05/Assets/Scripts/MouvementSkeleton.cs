using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementSkeleton : MonoBehaviour
{
    [SerializeField]
    private GameObject terrain;

    [SerializeField]
    private float vitesseDeplacement = 2f;

    [SerializeField]
    private float vitesseRotation = 200f;
    private Animator animator;

    private Vector3 objectif;
    private Coroutine coroutineDeplacer;
    private Coroutine coroutineRotater;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            animator.SetTrigger("Attack");
        }


        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 positionSouris = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(positionSouris);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == terrain)
                {
                    if (coroutineDeplacer != null) StopCoroutine(coroutineDeplacer);
                    if (coroutineRotater != null) StopCoroutine(coroutineRotater);

                    objectif = hit.point;

                    Vector3 direction = (objectif - transform.position).normalized;
                    coroutineDeplacer = StartCoroutine(DeplacerPersonnage(direction));

                    Quaternion rotationFinale = Quaternion.LookRotation(direction);
                    coroutineRotater = StartCoroutine(RotaterPersonnage(rotationFinale));
                }
            }
        }


    }


    private IEnumerator DeplacerPersonnage(Vector3 direction)
    {
        animator.SetBool("Walk", true);
        while ((transform.position - objectif).magnitude > 0.5f)
        {
            transform.position += vitesseDeplacement * direction * Time.deltaTime;
            yield return null;
        }

        animator.SetBool("Walk", false);
    }

    private IEnumerator RotaterPersonnage(Quaternion rotationFinale)
    {
        while (Quaternion.Angle(transform.rotation, rotationFinale) > 0.01f)
        {
            float rotationAppliquee = vitesseRotation * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationFinale, rotationAppliquee);
            yield return null;
        }
    }






}
