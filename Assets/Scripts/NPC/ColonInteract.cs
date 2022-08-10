using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class ColonInteract : MonoBehaviour, IInteractive
{
    bool interacted = false;
    public bool Interacted { get => interacted; set => interacted = value; }
    [SerializeField] Movement ship;
    [SerializeField] Outline outline;
    [SerializeField] GameObject screen;
    [SerializeField] VR_Teleport tp;



    public void Interact()
    {
        if (interacted) print("|NPC : Colon| CAN'T INTERACT, Has already been interacted with");
        else
        {
            if (ship.HasStoped)
            {
                tp.enabled = true;

                outline.OutlineWidth = 0;
                screen.SetActive(true);
                interacted = true;

                print("|NPC : Colon| Interacted succesfully");
            }
            else print("|NPC : Colon| CAN'T INTERACT, Interaction condition hasn't been achieved");
        }     
    }
}
