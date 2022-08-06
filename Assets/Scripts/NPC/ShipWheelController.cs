using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWheelController : MonoBehaviour, IInteractive
{
    bool interacted = false;
    [SerializeField] Movement ship;
    [SerializeField]
    OtherShipsMovement[] ships;
    [SerializeField] Outline cOutline;

    public bool Interacted { get => interacted; set => interacted = value; }

    public void Interact()
    {
        if (interacted) print("|STEERING WHEEL| CAN'T INTERACT, Has already been interacted with");
        else
        {
            ship.Move();
            cOutline.OutlineWidth = 4;
            this.GetComponent<Outline>().OutlineWidth = 0;
            interacted = true;

            print("|STEERING WHEEL| Interacted succesfully");

            foreach (var sh in ships)
            {
                sh.StartShipMovement();
            }
        }

    }
}
