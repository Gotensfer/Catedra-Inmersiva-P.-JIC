using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWheelController : MonoBehaviour, IInteractive
{
    bool interacted = false;
    [SerializeField] Movement ship;
    [SerializeField] Outline cOutline;

    public bool Interacted { get => interacted; set => interacted = value; }

    public void Interact()
    {
        print("mmgvo");
        ship.CanMove = true;
        cOutline.Eenabled(true);
    }
}
