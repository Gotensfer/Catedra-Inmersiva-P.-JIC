using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonInteract : MonoBehaviour, IInteractive
{
    bool interacted = false;
    public bool Interacted { get => interacted; set => interacted = value; }
    [SerializeField] Movement ship;
    [SerializeField] Outline cOutline;

    public void Interact()
    {
        if (cOutline.isActiveAndEnabled)
        {
            print("Se reproduce el video que no tenemos");
        }      
    }
}
