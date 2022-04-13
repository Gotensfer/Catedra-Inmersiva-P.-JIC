using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractive 
{
    public bool Interacted { get; set; }
    public void Interact();
}
