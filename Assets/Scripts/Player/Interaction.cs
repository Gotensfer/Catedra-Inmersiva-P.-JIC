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
            interactive.InteractMeter += Time.fixedDeltaTime / 2f;

            if (!interactive.Interacted && interactive.InteractMeter == 1)
            {
                interactive.Interacted = true;
                interactive.Interact();
            }
        }
        
    }
}
