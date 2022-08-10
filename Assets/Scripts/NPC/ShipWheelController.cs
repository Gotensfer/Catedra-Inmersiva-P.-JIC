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

    [SerializeField] BoxCollider buttonCollider;
    [SerializeField] VR_Button vR_Button;

    [SerializeField] GameObject wheelEventText;
    [SerializeField] GameObject wheelEventResolutionText;
    [SerializeField] GameObject anchorEventBegin;

    public bool Interacted { get => interacted; set => interacted = value; }

    public void Interact()
    {
        if (interacted) print("|STEERING WHEEL| CAN'T INTERACT, Has already been interacted with");
        else
        {
            this.GetComponent<Outline>().OutlineWidth = 0;
            interacted = true;

            print("|STEERING WHEEL| Interacted succesfully");

            foreach (var sh in ships)
            {
                sh.StartCoroutine(sh.BeginMovement());
            }

            Invoke(nameof(AllowAnchorEvent), 8f);

            wheelEventText.SetActive(false);
            wheelEventResolutionText.SetActive(true);
        }
    }

    void AllowAnchorEvent()
    {
        buttonCollider.enabled = true;
        vR_Button.outline.OutlineWidth = 2;
        vR_Button.anchorEventIsOn = true;

        wheelEventResolutionText.SetActive(false);
        anchorEventBegin.SetActive(true);
    }
}
