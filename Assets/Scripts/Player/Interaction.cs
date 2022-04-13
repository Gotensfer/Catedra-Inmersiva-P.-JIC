using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        IInteractive interactive = other.GetComponent<IInteractive>();

        if (interactive != null)
        {
            //Button.One es (supuestamente) el botón para Oculus Rift, es imposible hacer pruebas reales sin el Oculus Quest disponible
            if (Input.GetButtonDown("Fire1") && !interactive.Interacted)
            {
                interactive.Interacted = true;
                interactive.Interact();
            }
        }        
    }
}
