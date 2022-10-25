using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class MakePhantom : MonoBehaviour
{
    BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    public void MakeTrigger()
    {
        boxCollider.isTrigger = true;
    }

    public void MakePhysic()
    {
        boxCollider.isTrigger = false;
    }
}
