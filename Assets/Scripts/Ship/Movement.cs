using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{


    bool canMove = false;
    public bool CanMove { get => canMove; set => canMove = value;}

    bool alreadyMoved = false;
    public bool AlreadyMoved { get => alreadyMoved; set => alreadyMoved = value; }

    [SerializeField] Transform endPosition;
    [SerializeField] float timeToReachEnd;

    public void Move()
    {
        if (!alreadyMoved)
        {
            transform.DOMove(endPosition.position, timeToReachEnd).SetEase(Ease.InOutSine);
            alreadyMoved = true;
        }
    }
}
