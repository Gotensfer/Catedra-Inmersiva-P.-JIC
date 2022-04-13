using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPC : MonoBehaviour, IInteractive
{
    bool interacted = false;

    public bool Interacted { get => interacted; set => interacted = value; }

    public void Interact()
    {
        print("You interacted with me");
        // Do stuff
    }
}
