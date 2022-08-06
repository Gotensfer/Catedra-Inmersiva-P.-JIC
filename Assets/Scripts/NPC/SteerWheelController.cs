using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerWheelController : MonoBehaviour, IInteractive
{
    bool interacted = false;
    [SerializeField] Movement ship;

    public bool Interacted { get => interacted; set => interacted = value;}

    private void Start()
    {
        ship = GetComponent<Movement>();
    }
    public void Interact()
    {
    }
}
