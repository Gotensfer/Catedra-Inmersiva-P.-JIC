using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColonInteract : MonoBehaviour, IInteractive
{
    bool interacted = false;
    public bool Interacted { get => interacted; set => interacted = value; }
    [SerializeField] Movement ship;
    [SerializeField] Outline outline;
    [SerializeField] GameObject screen;

    public void Interact()
    {
        if (ship.CanMove)
        {
            print("Se reproduce el video que no tenemos");
            outline.OutlineWidth = 0;
            screen.SetActive(true);
        }  

        else interacted = false;
    }
}
