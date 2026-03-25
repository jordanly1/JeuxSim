using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GestionnaireJeu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            var objet = Utilitaires.DeterminerClic();

    
            if (objet != null)
            {
                var clic = objet.GetComponent<ICliquable>();

                if (clic != null)
                {
                    clic.Clic();
                }

            }
        }
    }
}