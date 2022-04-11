using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractive 
{
    public float InteractMeter { get; set; }
    public bool Interacted { get; set; }
    public void Interact();
}
