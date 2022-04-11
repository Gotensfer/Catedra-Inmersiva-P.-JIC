using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPC : MonoBehaviour, IInteractive
{
    float interactMeter = 0;
    bool interacted = false;

    public float InteractMeter
    {
        get => interactMeter;
        set
        {
            if (value < 0) interactMeter = 0;
            else if (value > 1) interactMeter = 1;
            else interactMeter = value;
        } 
    }

    public bool Interacted { get => interacted; set => interacted = value; }

    public void Interact()
    {
        print("You interacted with me");
        // Do stuff
    }
}
